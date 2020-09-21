using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSearchedSubstance : MonoBehaviour
{
    float time;
    public Scenario1 Scenario1;
    public GameObject Instatieted;
    public GameObject HardSubstance;
    public GameObject LiqSubstance;
    public ObiParticleRenderer WaterEmitter;
    public ObiParticleRenderer FluidEmitter;

    //public GameObject TemperatureText;
    public Scenario3 Scenario3;
    public GameObject Camera;
    List<Subst> Substances = new List<Subst>();
    public GameObject EndWaterEmitter;
    public GameObject EndLiqSubstEmitter;


    // Start is called before the first frame update
    void Start()
    {
        List<Subst> Subst = new List<Subst>();
        Subst.Add(new Subst("CuSO4", true, 100, false, Color.blue));
        Subst.Add(new Subst("NiCL2", true, 100, false, Color.green));
        Subst.Add(new Subst("CoCl2", true, 100, false, new Color(248, 24, 148)));
        Substances = Subst;

        time = 0.5f;
    }


    public void OnClicked(Button button)
    {
        Scenario1.Selected = true;
        if (Instatieted != null)
        {
            Instatieted.SetActive(false);
            Destroy(Instatieted);
            //Instatieted = null;
        }
        string name = button.transform.GetChild(0).GetComponent<Text>().text;
        foreach (Subst subst in Substances)
        {
            if(subst.name == name)
            {
                int temperature = (int)subst.temp;
                if (subst.aggregate)
                {
                    Instatieted = Instantiate(HardSubstance);
                    /*if (subst.solubility)
                    {
                        Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().mix = true;
                    }
                    else
                    {
                        Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().mix = false;
                    }*/
                    temperature = 100;
                    GameObject.FindGameObjectWithTag("controller").GetComponent<ControlIsparitel>().HardSubstActivatel = Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().HardSubstance;
                }
                else
                {
                    Instatieted = Instantiate(LiqSubstance);
                    FluidEmitter = GameObject.FindGameObjectWithTag("fluidEmitter").GetComponent<ObiParticleRenderer>();
                    //Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().WaterRenderer = WaterEmitter;
                    GameObject.FindGameObjectWithTag("substance").GetComponent<Mixing>().FluidRederer = FluidEmitter;
                    FluidEmitter.particleColor = subst.color;
                    //GameObject.FindGameObjectWithTag("substance").GetComponent<Mixing>().FluidRederer.particleColor = subst.color;

                    /*if (subst.solubility)
                    {
                        Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().mix = true;
                    }
                    else
                    {
                        Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().mix = false;
                    }*/
                    //Camera.GetComponent<ObiFluidRenderer>().particleRenderers[0] = Instatieted.transform.GetChild(0).GetChild(0).GetComponent<Mixing>().FluidRederer;
                    Camera.GetComponent<ObiFluidRenderer>().particleRenderers[0] = FluidEmitter;

                    print("температура = " + temperature);
                    if(temperature >= 100)
                    {
                        temperature = 100;
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag("controller").GetComponent<ControlIsparitel>().emitter1 = null;
                        GameObject.FindGameObjectWithTag("controller").GetComponent<ControlIsparitel>().emitter2 = EndLiqSubstEmitter;

                    }
                }
                Scenario3.necessaryTemp = temperature;
                GameObject.FindGameObjectWithTag("FluidBottle").GetComponent<Mixing>().SubstName.text = subst.name;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (time < 0)
        {
            //Substances = Subst;
            //time -= Time.deltaTime;

        }

    }
}
