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
        List<Subst> Substances = gameObject.GetComponent<Request>().Substances;
        count = Substances.Count;
        Button.transform.GetChild(0).GetComponent<Text>().text = Substances[0].name;
        //Button.GetComponent<Button>().onClick.AddListener(gameObject.GetComponent<ControlIsparitel>().ReloadSc);

        for (int i = 1; i < count; i++)
        {
            GameObject NewButton = Instantiate(Button, Button.transform.parent);
            NewButton.transform.position -= new Vector3(0, 3 * i, 0);
            NewButton.transform.GetChild(0).GetComponent<Text>().text = Substances[i].name;
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
