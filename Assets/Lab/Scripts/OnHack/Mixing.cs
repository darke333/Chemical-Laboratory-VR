using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using UnityEngine.UI;
using TMPro;

public class Mixing : MonoBehaviour
{


    public bool Splited;
    public Obi.ObiSolver solver;
    private Obi.ObiEmitter emitter;
    private int totalParticles;
    private HashSet<int> collidedParticles;
    [Range(0, 1)]
    public float failRatio = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        //Splited = false;
        //collidedParticles = new HashSet<int>();
        //emitter = FluidRederer.gameObject.GetComponent<Obi.ObiEmitter>();
        //solver = FluidRederer.gameObject.GetComponent<Obi.ObiSolver>();
        //solver.OnCollision += HandleCollision;
        //totalParticles = emitter.NumParticles;
    }

    /*private void HandleCollision(object sender, ObiSolver.ObiCollisionEventArgs e)
    {
        foreach (Oni.Contact contact in e.contacts)
        {
            // this one is an actual collision:
            if (contact.distance < 0.01)
            {
                //print(collidedParticles.Count);
                //print(totalParticles);

                Component collider;
                if (ObiCollider.idToCollider.TryGetValue(contact.other, out collider))
                {
                    if (collidedParticles.Contains(contact.particle))
                        return;

                    if (collider.CompareTag("water"))
                        collidedParticles.Add(contact.particle);
                    if ((float)collidedParticles.Count / totalParticles >= failRatio)
                    {
                        Splited = true;//========================================================================
                        Color color = Color.Lerp(WaterRenderer.particleColor, FluidRederer.particleColor, 0.5f);
                        WaterRenderer.particleColor = color;
                        FluidRederer.particleColor = color;
                        GameObject.FindGameObjectWithTag("scenario1").GetComponent<Scenario1>().Mixed = true;
                        Destroy(collider);
                        Destroy(this);
                    }
                    // do something with the collider.
                }
            }
        }
    }*/



    public TextMeshProUGUI SubstName;
    public bool water;
    public bool mix;
    public ObiParticleRenderer WaterRenderer;
    public ObiParticleRenderer FluidRederer;
    public GameObject HardSubstance;



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "substance" && gameObject.tag == "water" || gameObject.tag == "substance" && other.tag == "water")
        {
            print("Inside");
            Invoke("EnableMixing", 3);
        }
    }

    void EnableMixing()
    {
        if (water)
        {

            Color color = Color.Lerp(WaterRenderer.particleColor, FluidRederer.particleColor, 0.5f);
            WaterRenderer.particleColor = color;
            FluidRederer.particleColor = color;
        }
        else
        {
            HardSubstance.SetActive(false);
        }
        GameObject.FindGameObjectWithTag("scenario1").GetComponent<Scenario1>().Mixed = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
