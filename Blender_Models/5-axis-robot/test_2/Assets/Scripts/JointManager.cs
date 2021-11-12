using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointManager : MonoBehaviour
{
    public int m_steps = 20;
    public float m_rate = 10f;
    public float m_threshold = 0.05f;
    public Joint m_root;
    public Joint m_end;
    public GameObject m_target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_steps; i++)
        {
            if (GetDistance(m_end.transform.position, m_target.transform.position) > m_threshold)
            {
                Joint current = m_root;
                while (current != m_end)
                {
                    float slope = CalculateSlope(current);
                    RotateJoint(ref current, slope);
                    current = current.GetChild();
                }
            }
        }
    }
    void RotateJoint(ref Joint current, float angle)
    {
        float max_pos_rotation = 60;
        float max_neg_rotation = -60;

        float currentRotation = current.GetRotation().y;
        //if (currentRotation < max_pos_rotation && currentRotation > max_neg_rotation )
        //if (currentRotation < max_pos_rotation )
        {
            Debug.Log(current.GetName() + "_x: " + current.GetRotation().x);
            Debug.Log(current.GetName() + "_y: " + current.GetRotation().y);
            Debug.Log(current.GetName() + "_z: " + current.GetRotation().z);
            current.Rotate(-angle * m_rate);
        }
    }

    float CalculateSlope(Joint _joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(m_end.transform.position, m_target.transform.position);
        _joint.Rotate(deltaTheta);

        float distance2 = GetDistance(m_end.transform.position, m_target.transform.position);
        _joint.Rotate(-deltaTheta);

        return (distance2-distance1) / deltaTheta;
    }
    float GetDistance(Vector3 p1, Vector3 p2)
    {
        return Vector3.Distance(p1,p2);
    }
}
