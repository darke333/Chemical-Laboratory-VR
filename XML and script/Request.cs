using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

public class Subst
{
    public string name;
    public bool solubility;
    public double temp;
    public bool aggregate;

    public Subst(string Name, bool Solubility, double Temp, bool Aggregate)
    {
        name = Name;
        solubility = Solubility;
        temp = Temp;
        aggregate = Aggregate;
    }
}
public class Request : MonoBehaviour
{
    public List<Subst> Substances = new List<Subst>();
    /// <summary>
    /// Если Solid -> true, Если Liquid -> false
    /// </summary>
    /// <param name="childnode"></param>
    /// <returns></returns>
    public bool Aggregate(XmlNode childnode)
    {
        Regex regex = new Regex(@"solid");
        MatchCollection matches = regex.Matches(childnode.InnerText);
        if (matches.Count > 0)
        {
            if (matches[0].Value == "solid")
                return true;
            else
            {
                return false;
            }
        }
        else
            return false;
    }

    /// <summary>
    /// Soluble -> true, Если Unsoluble -> false
    /// </summary>
    /// <param name="childnode"></param>
    /// <returns></returns>
    public bool Solubility(XmlNode childnode)
    {
        Regex regex = new Regex(@"soluble");
        MatchCollection matches = regex.Matches(childnode.InnerText);
        if (matches.Count > 0)
        {
            if (matches[0].Value == "soluble")
                return true;
            else
            {
                return false;
            }
        }
        else
            return false;
    }

    public double Temp(XmlNode childnode)
    {
        Regex regex = new Regex(@"\d*\s°C");
        MatchCollection matches = regex.Matches(childnode.InnerText);
        if (matches.Count > 0)
        {
            
            string x = matches[matches.Count-1].Value; //достаем послдений элемент массива
            int x1 = x.Length - 3;
            x = x.Remove(x1);
            return double.Parse(x);
        }
        else
            return 100;
    }

    public string Name(XmlNode childnode)
    {
        string[] strs = new string[childnode.InnerText.Length];
        string str = childnode.InnerText;
        strs = str.Split('|');
        str = "";
        foreach (char st in strs[strs.Length-1])
        {
            str += st;
        }

        str = str.Remove(0, 1);
        return str;

    }

    public void get_http_write(string url, string page)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        //req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:17.0) Gecko/20100101 Firefox/17.0";
        //req.CookieContainer = cookies;
        //req.Headers.Add("DNT", "1");

        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream stream = resp.GetResponseStream();
        StreamReader sr = new StreamReader(stream);
        //resp.Close();
        string text = sr.ReadToEnd();
        // sr.Close();
        using (var sw = new StreamWriter(page))
            sw.Write(text); //пишем на комп
        resp.Close();
        sr.Close();
    }

    /// <summary>
    /// Заполняет массив следующим списком наименований xml файлов
    /// </summary>
    /// <param name="Subs"></param>
    /// <param name="pages"></param>
    public void FillArray(List<Subst> Subs, string[] pages)
    {
        List<XmlDocument> docs = new List<XmlDocument>();
        for (int j = 0; j <= pages.Length-1; j++)
        {
            docs.Add(new XmlDocument());
        }
        int i = 0;
        foreach (XmlDocument doc in docs)
        {
            doc.Load(System.Environment.CurrentDirectory+"/XML and script/" + pages[i]);// ПУТЬ-------------------------------------------------------------------------------
            bool solubility = false;
            double temp = 100;
            bool aggregate = false;
            string name = "noname";
            XmlElement xRoot = doc.DocumentElement;

            foreach (XmlNode childnode in xRoot) //Цикл для получения трех параметров (имя мы получаем из Sub2.txt)
            {
                if (childnode.Name == "pod" && childnode.Attributes.GetNamedItem("title").Value == "Basic properties")
                {
                    foreach (XmlNode childnode2 in childnode.ChildNodes)
                    {
                        if (childnode2.Name == "subpod")
                        {
                            foreach (XmlNode childnode3 in childnode.ChildNodes)
                            {
                                if (childnode3.Name == "subpod")
                                {
                                    foreach (XmlNode childnode4 in childnode3.ChildNodes)
                                    {
                                        if (childnode4.Name == "plaintext")
                                        {
                                            //Subs.Add(new Substance(null, Solubility(childnode4), Temp(childnode4), Aggregate(childnode4)));
                                            solubility = Solubility(childnode4);
                                            temp = Temp(childnode4);
                                            aggregate = Aggregate(childnode4);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            /*
            foreach (XmlNode childnode in xRoot) //Код для получения имени из XML файла
            {
                if (childnode.Name == "pod" && childnode.Attributes.GetNamedItem("title").Value == "Chemical names and formulas")
                {
                    foreach (XmlNode childnode2 in childnode)
                    {
                        if (childnode2.Name == "subpod")
                        {
                            foreach (XmlNode childnode3 in childnode2)
                            {
                                if (childnode3.Name == "plaintext")
                                {
                                    name = Name(childnode3);
                                }
                            }
                        }
                    }
                }
            }
            */
            Subs.Add(new Subst(name, solubility, temp, aggregate));
            i++;
        }

        foreach (Subst sub in Substances) //Удаление всех ошибочных веществ на последней стадии формирования массива
        {
            if (sub.name == "noname")
                Substances.Remove(sub);
        }
    }


    // Start is called before the first frame update
    void Start()
    {      
        FileStream FS = new FileStream(System.Environment.CurrentDirectory+"/XML and script/Sub2.txt", FileMode.OpenOrCreate);
        StreamReader Str = new StreamReader(FS);
        string stroka = Str.ReadToEnd();
        FS.Close();
        Str.Close();
        string[] elements = System.Text.RegularExpressions.Regex.Split(stroka, "\r\n");

       // int i = 0;
        /*
        foreach (string element in elements)
        {
        //    get_http_write("http://api.wolframalpha.com/v2/query?input=" + element + "&appid=K58ETV-GTPAJVATGW", "pageTR" + i + ".xml");
            i++;
        }
        */



        
        string[] pages = new string[elements.Length]; //Код записи СУЩЕСТВУЮЩИХ ФАЙЛОВ В МАССИВ Substances
        for (int j = 0; j<elements.Length; j++)
        {
            pages[j] = "page" + j + ".xml";
        }
        

        FillArray(Substances, pages);

        int h = 0;
        foreach (Subst Sub in Substances) //заполнение имен веществ
        {
            Sub.name = elements[h];
            h++;
        }
    }
        
            // Update is called once per frame
            void Update()
            {

            }
}
    

