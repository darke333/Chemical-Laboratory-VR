﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using UnityEngine.UI;
using TMPro;

public class Mixing : MonoBehaviour
{
    public TextMeshProUGUI SubstName;
    public bool water;
    public bool mix;
    public ObiParticleRenderer WaterRenderer;
    public ObiParticleRenderer FluidRederer;
    public GameObject HardSubstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "substance" && gameObject.tag == "water" || gameObject.tag == "substance" && other.tag == "water")
        {
            print("Inside");
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
