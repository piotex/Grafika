using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint m_child;
    public Joint GetChild()
    {
        return m_child;
    }
    public void Rotate(float _angle)
    {
        transform.Rotate(new Vector3(0,0,1) * _angle);
    }
    public float GetCriticAxisRotation()
    {
        switch (transform.name)
        {
            case "1":
                return transform.localEulerAngles.z;
            case "2":
                return transform.localEulerAngles.y;
            case "3":
                return transform.localEulerAngles.z;
            case "4":
                return transform.localEulerAngles.z;
            case "5":
                return transform.localEulerAngles.z;
            default:
                return transform.localEulerAngles.z;
        }
        throw new System.Exception("Join-GetCriticAxisRotation");
        return 0;
    }
    public bool IsJoinIn_GOOD_Rotation()
    {
        int max = 60;
        int min = -60;
        switch (transform.name)
        {
            case "1":
                max = 60+90;
                min = -60+90;
                return max > transform.localEulerAngles.z && transform.localEulerAngles.z > min;
            case "2":
                max = 60+90;
                min = -60+90;
                return max > transform.localEulerAngles.y && transform.localEulerAngles.y > min;
            case "3":
                max = 60;
                min = -60;
                //return max > transform.localEulerAngles.z && transform.localEulerAngles.z > min;
                return true;
            case "4":
                max = 60;
                min = -60;
                //return max > transform.localEulerAngles.z && transform.localEulerAngles.z > min;
                return true;
            case "5":
                max = 60;
                min = -60;
                //return max > transform.localEulerAngles.z && transform.localEulerAngles.z > min;
                return true;
            default:
                //return max > transform.localEulerAngles.z && transform.localEulerAngles.z > min;
                return true;
        }
        throw new System.Exception("Join-IsJoinInCriticRotation");
        return true;
    }
    public string GetName()
    {
        return transform.name;
    }
}
