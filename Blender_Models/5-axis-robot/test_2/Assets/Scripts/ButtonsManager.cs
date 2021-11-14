using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public bool Start = false;
    public float Speed = 2;
    public Joint EndEfector;
    public GameObject Target;
    private int index = 0;

    public readonly List<Vector3> CyclePointList = new List<Vector3>()
    {
        //new Vector3(6.6f, 17.05f, -8.8f),
        //new Vector3(7.81f, 3.69f, -8.8f),
        //new Vector3(7.81f, 13.07f, 7.16f),
        //new Vector3(7.81f, 23.07f, 7.16f),

        new Vector3(3.2f, 4.8f, 8.8f),
        new Vector3(5.6f, 25.2f, 1.2f),
        new Vector3(7.2f, 15.2f, -5.2f),
        new Vector3(12.6f, 7.2f, -4.2f),

    };


    // Update is called once per frame
    void Update()
    {
        if (Start)
        {
            SingleCycle();
        }
    
    }


    public void CycleStart()
    {
        for (int i = 0; i < CyclePointList.Count; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = CyclePointList[i];
        }
        Target.transform.position = CyclePointList[index];

        Start = !Start;
    }
    public void SingleCycle()
    {
        float precision = 0.1f;
        if (Vector3.Distance(EndEfector.transform.position, CyclePointList[index]) <= precision)
        {
            for (int i = 0; i < 10; i++)
            {
                Time.timeScale = (float)(i/10);
            }

            index++;
            if (index >= CyclePointList.Count)
            {
                index = 0;
            }
            Target.transform.position = CyclePointList[index];
        }
    }
}
