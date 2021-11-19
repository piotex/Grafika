using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    private int index = 0;
    private bool startCycle = false;
    private GameObject tmp_sphere;

    public Joint EndEfector;
    public GameObject Target;

    public Text ErrorTextPlace;

    public readonly List<Vector3> CyclePointList = new List<Vector3>()
    {
        //new Vector3(3.2f, 4.8f, 8.8f),
        //new Vector3(5.6f, 25.2f, 1.2f),
        //new Vector3(7.2f, 15.2f, -5.2f),
        //new Vector3(12.6f, 7.2f, -4.2f),
    };

    private void Start()
    {
        tmp_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    void Update()
    {
        if (startCycle)
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

        startCycle = !startCycle;
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

    public void AddPoint()
    {
        int x = 1;
    }
    public void PointTextbox_ValueChanged(String _text)
    {
        /*
        float x = 0;
        float y = 0;
        float z = 0;

        int tmp_index = 0;
        string tmp = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (';' == text[i])
            {
                if (tmp_index == 2)
                {
                    z = float.Parse(tmp.Trim());
                    tmp_index++;
                    tmp = "";
                }
                if (tmp_index == 1)
                {
                    y = float.Parse(tmp.Trim());
                    tmp_index++;
                    tmp = "";
                }
                if (tmp_index == 0)
                {
                    x = float.Parse(tmp.Trim());
                    tmp_index++;
                    tmp = "";
                }
            }
            else
            {
                tmp += text[i];
            }
        }

        tmp_sphere.transform.position = new Vector3(x,y,z);
        */

        if (_text != null && _text != "")
        {
            ErrorTextPlace.text = _text;
        }
        else
        {
            ErrorTextPlace.text = "lipa";
        }
    }
}
