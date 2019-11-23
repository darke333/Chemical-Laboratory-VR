using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDown : MonoBehaviour
{
    /// <summary>
    /// Сюда надо загрузить граф материала
    /// </summary>
    public Substance.Game.SubstanceGraph Graph;
    private float value;
    /// <summary>
    /// Сюда надо поставить значение true, если хочешь, чтобы стекло запотело и наоборот
    /// </summary>
    public bool IsDown;
    // Start is called before the first frame update
    void Start()
    {
        Graph.SetInputFloat("WaterLevel1", 0);
        Graph.SetInputFloat("WaterLevel2", 0);
        Graph.SetInputFloat("Change_0_1", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDown && Graph.GetInputFloat("WaterLevel1") < 1)
        {
            value += Time.deltaTime * 0.7f;
            Graph.SetInputFloat("WaterLevel1", value);
            Graph.QueueForRender();
            Graph.RenderSync();
        }
        if (!IsDown && Graph.GetInputFloat("WaterLevel2") < 1)
        {
            value += Time.deltaTime * 0.7f;
            Graph.SetInputFloat("WaterLevel2", value);
            Graph.QueueForRender();
            Graph.RenderSync();
        }
        if (Input.GetButtonDown("Jump"))
        {
            ChangeBehavior(); 
        }
    }

    public void ChangeBehavior()
    {
        value = 0;
        if (IsDown)
        {
            Graph.SetInputFloat("Change_0_1", 0);
            Graph.SetInputFloat("WaterLevel1", 0);
            IsDown = false;
        }
        else
        {
            Graph.SetInputFloat("Change_0_1", 1);
            Graph.SetInputFloat("WaterLevel2", 0);
            IsDown = true;
        }
    }

}
