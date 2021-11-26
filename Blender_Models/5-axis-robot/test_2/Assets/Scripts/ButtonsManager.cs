using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    private int index = 0;
    private bool doCycles = false;
    private bool showPath = true;
    private GameObject tmp_sphere;

    public Joint EndEfector;
    public GameObject Target;

    public Text ErrorTextPlace;
    public Text PointInput;

    public List<Vector3> CyclePointList = new List<Vector3>()
    {
        /*
        new Vector3(3.2f, 4.8f, 8.8f),
        new Vector3(5.6f, 25.2f, 1.2f),
        new Vector3(7.2f, 15.2f, -5.2f),
        new Vector3(12.6f, 7.2f, -4.2f),
        */
    };
    public List<GameObject> PathList = new List<GameObject>();


    private void Start()
    {
        tmp_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        tmp_sphere.GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        if (doCycles)
        {
            SingleCycle();
        }
        if (showPath)
        {
            for (int i = 0; i < PathList.Count; i++)
            {
                PathList[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < PathList.Count; i++)
            {
                PathList[i].SetActive(false);
            }
        }
    }

    public void CycleStart()
    {
        //addCycleSphersToView();
        Target.transform.position = CyclePointList[index];

        doCycles = !doCycles;
    }
    public void ShowHidePath()
    {
        showPath = !showPath;
        addCycleSphersToView();
    }
    public void AddPoint()
    {
        float _factor = 2f;
        Vector3 dest_point = parseStringToVector(PointInput.text);

        if (CyclePointList.Count > 0)
        {
            Vector3 last_pos = CyclePointList[CyclePointList.Count - 1];
            if (isTwoVectorDiferent(dest_point,last_pos))                                       //jezeli dest jest inny od ostatniego punktu w tablicy
            {
                int _steps_count = (int)Vector3.Distance(dest_point,last_pos);
                Vector3 _pos_dif = (dest_point - last_pos)/_factor;
                Vector3 _step = _pos_dif / _steps_count;

                for (int i = 1; i <= _steps_count*_factor; i++)
                {
                    Vector3 _new_pos = last_pos + (_step * i);
                    _addPointToListOfOrders(_new_pos);

                }
            }
        }
        else
        {
            _addPointToListOfOrders(dest_point);
        }


        ErrorTextPlace.text = "lista zawiera: " + CyclePointList.Count;
    }
    public void PointTextbox_ValueChanged(String _text)
    {
        tmp_sphere.transform.position = parseStringToVector(_text);
    }



    //----------------------------//----------------------------//------------- U T I L S ---------------//----------------------------//----------------------------//----------------------------

    private void SingleCycle()
    {
        if (!isTwoVectorDiferent(EndEfector.transform.position, CyclePointList[index]))
        {
            changeTarget();
        }
    }
    private void _addPointToListOfOrders(Vector3 vec)
    {
        CyclePointList.Add(vec);
    }
    private void changeTarget()
    {
        index++;
        if (index >= CyclePointList.Count)
        {
            index = 0;
        }
        Target.transform.position = CyclePointList[index];
    }
    private void addCycleSphersToView()
    {
        for (int i = 0; i < CyclePointList.Count; i++)
        {
            addNormalSphersToView(CyclePointList[i]);
        }
    }
    private void addNormalSphersToView(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        tmp_sphere.GetComponent<Renderer>().material.color = Color.green;
        //PathList.Add(sphere);
    }
    private void addSmallSphersToView(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        tmp_sphere.GetComponent<Renderer>().material.color = Color.grey;
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    private bool isTwoVectorDiferent(Vector3 v1, Vector3 v2)
    {
        float precision = 0.05f;                                                                            //dla 0.01 utyka w 3 punkcie :<
        return Vector3.Distance(v1, v2) > precision;
    }
    private Vector3 parseStringToVector(string text)
    {
        Vector3 ret = new Vector3();

        int tmp_index = 0;
        string tmp = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (';' == text[i])
            {
                if (tmp_index == 2)
                {
                    ret.z = float.Parse(tmp.Trim());
                    tmp_index++;
                    tmp = "";

                    break;  //to be faster
                }
                if (tmp_index == 1)
                {
                    ret.y = float.Parse(tmp.Trim());
                    tmp_index++;
                    tmp = "";
                }
                if (tmp_index == 0)
                {
                    ret.x = float.Parse(tmp.Trim());
                    tmp_index++;
                    tmp = "";
                }
            }
            else
            {
                tmp += text[i];
            }
        }

        return ret;
    }
}



/*
 * w razie problemow z dotarciem mozna wykozystac:
            for (int i = 0; i < 10; i++)
            {
                Time.timeScale = (float)(i/10);
            }
*
*/
