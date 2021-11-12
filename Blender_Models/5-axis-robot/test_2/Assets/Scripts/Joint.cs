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
    public Vector3 GetRotation()
    {
        
        return transform.eulerAngles;
    }
    public string GetName()
    {
        return transform.name;
    }
}
