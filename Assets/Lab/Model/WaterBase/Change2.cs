using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change2 : MonoBehaviour
{
    /// <summary>
    /// Сюда надо загрузить граф материала
    /// </summary>
    public Substance.Game.SubstanceGraph Graph;
    private float value;
    /// <summary>
    /// Сюда надо поставить значение true, если хочешь, чтобы стекло запотело и наоборот
    /// </summary>
    public bool mist;
    // Start is called before the first frame update
    void Start()
    {
        value = Graph.GetInputFloat("Normal");
    }

    // Update is called once per frame
    void Update()
    {
        if (mist && value < 1)
        { 
            value += Time.deltaTime * 0.1f;
            Graph.SetInputFloat("Normal", value);
            Graph.SetInputFloat("Roughness", value);
            Graph.QueueForRender();
            Graph.RenderSync();
        }
        if (!mist && value > 0)
        {
            value -= Time.deltaTime * 0.1f;
            Graph.SetInputFloat("Normal", value);
            Graph.SetInputFloat("Roughness", value);
            Graph.QueueForRender();
            Graph.RenderSync();
        }
    }

}
