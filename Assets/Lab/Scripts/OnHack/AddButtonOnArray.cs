using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtonOnArray : MonoBehaviour
{
    public int count;
    public GameObject Button;
    float time;
    //public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.5f;
    }



    void AddButton()
    {

        List<Subst> Substances = new List<Subst>();
        Substances.Add(new Subst("CuSO4", true, 100, false, Color.blue));
        Substances.Add(new Subst("NiCL2", true, 100, false, Color.green));
        Substances.Add(new Subst("CoCl2", true, 100, false, new Color(0.972f, 0.094f, 0.580f)));
        List<Subst> substs = new List<Subst>();
        foreach (Subst subst in Substances)
        {
            if(subst.temp > 50 && !subst.aggregate)
            {
                substs.Add(subst);
            }
        }
        count = substs.Count;
        Button.transform.GetChild(0).GetComponent<Text>().text = substs[0].name;
        //Button.GetComponent<Button>().onClick.AddListener(gameObject.GetComponent<ControlIsparitel>().ReloadSc);

        for (int i = 1; i < count; i++)
        {
            if (substs[i].temp > 50)
            {
                GameObject NewButton = Instantiate(Button, Button.transform.parent);
                NewButton.transform.position -= new Vector3(0, 3 * i, 0);
                NewButton.transform.GetChild(0).GetComponent<Text>().text = substs[i].name;
            }

            //NewButton.GetComponent<Button>().onClick.AddListener(gameObject.GetComponent<AddSearchedSubstance>().OnClicked(gameObject.GetComponent<Button>()));

        }
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            AddButton();
            Destroy(this);
        }
    }
}
