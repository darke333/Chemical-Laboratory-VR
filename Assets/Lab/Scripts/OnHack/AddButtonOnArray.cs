using UnityEngine;
using UnityEngine.UI;

public class AddButtonOnArray : MonoBehaviour
{
    public int count;
    public GameObject Button;
    public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        
        Button.transform.GetChild(0).GetComponent<Text>().text = "Вещество 1";
        Button.GetComponent<Button>().onClick.AddListener(gameObject.GetComponent<ControlIsparitel>().ReloadSc);

        for (int i = 1; i < count; i++)
        {
            GameObject NewButton = Instantiate(Button, Button.transform.parent);
            NewButton.transform.position -= new Vector3(0,3*i,0);
            NewButton.transform.GetChild(0).GetComponent<Text>().text = "Вещество " +(i+1);
            NewButton.GetComponent<Button>().onClick.AddListener(gameObject.GetComponent<ControlIsparitel>().ReloadSc);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
