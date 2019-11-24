using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSearchedSubstance : MonoBehaviour
{
    public GameObject HardSubstance;
    public GameObject LiqSubstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClicked(Button button)
    {
        print(button.transform.GetChild(0).GetComponent<Text>().text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
