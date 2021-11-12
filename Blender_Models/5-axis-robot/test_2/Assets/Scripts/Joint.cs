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
        return 0;
    }
    public string GetName()
    {
        return transform.name;
    }
}
