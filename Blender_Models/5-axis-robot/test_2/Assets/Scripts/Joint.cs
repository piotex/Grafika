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
        int critic = 80;

        int max_1 = 60;
        int min_1 = -60;
        int max_2 = 60;
        int min_2 = -60; 
        
        switch (transform.name)
        {
            case "1":
                max_1 = 270 + critic;
                min_1 = 270 - critic;
                return max_1 > transform.localEulerAngles.z && transform.localEulerAngles.z > min_1;
            case "2":
                max_1 = 90 + critic;
                min_1 = 90 - critic;
                return max_1 > transform.localEulerAngles.y && transform.localEulerAngles.y > min_1;
            case "3":
                max_1 = 0 + critic;
                min_1 = 0;
                max_2 = 360 - 0;
                min_2 = 360 - critic;
                return (max_1 > transform.localEulerAngles.z && transform.localEulerAngles.z > min_1) || (max_2 > transform.localEulerAngles.z && transform.localEulerAngles.z > min_2);
            case "4":
                max_1 = 0 + critic;
                min_1 = 0;
                max_2 = 360 - 0;
                min_2 = 360 - critic;
                return (max_1 > transform.localEulerAngles.z && transform.localEulerAngles.z > min_1) || (max_2 > transform.localEulerAngles.z && transform.localEulerAngles.z > min_2);
            case "5":
                max_1 = 90 + critic;
                min_1 = 90 - critic;
                return max_1 > transform.localEulerAngles.z && transform.localEulerAngles.z > min_1;
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
