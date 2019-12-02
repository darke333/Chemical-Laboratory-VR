using System;
using System.Collections;
using System.Collections.Generic;
using Obi;

using UnityEngine;

public class DebugPool : MonoBehaviour
{
    public bool Splited;
    public Obi.ObiSolver solver;
    private Obi.ObiEmitter emitter;
    private int totalParticles;
    private HashSet<int> collidedParticles;
    [Range(0, 1)]
    public float failRatio = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        Splited = false;
        collidedParticles = new HashSet<int>();
        emitter = GetComponent<Obi.ObiEmitter>();
        solver.OnCollision += HandleCollision;
        totalParticles = emitter.NumParticles;
    }

    private void HandleCollision(object sender, ObiSolver.ObiCollisionEventArgs e)
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

                    if (collider.CompareTag("Obstacle"))
                        collidedParticles.Add(contact.particle);
                    if ((float)collidedParticles.Count / totalParticles >= failRatio)
                    {
                        Splited = true;//========================================================================
                    }
                    // do something with the collider.
                }
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
