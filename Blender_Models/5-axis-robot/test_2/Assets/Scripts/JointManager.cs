using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JointManager : MonoBehaviour
{
    public int m_steps = 20;
    public float m_rate = 10f;
    public float m_threshold = 0.05f;
    public Joint m_root;
    public Joint m_end;
    public GameObject m_target;

    public Text Text_Z_rotation_J0;
    public Text Text_Z_rotation_J1;
    public Text Text_Z_rotation_J2;
    public Text Text_Z_rotation_J3;
    public Text Text_Z_rotation_J4;
    public Text Text_Z_rotation_J5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < m_steps; i++)
        {
            if (GetDistance(m_end.transform.position, m_target.transform.position) > m_threshold)
            {
                Joint current = m_root;
                while (current != null)
                {
                    float slope = CalculateSlope(current);
                    RotateJoint(ref current, slope);

                    switch (current.GetName())
                    {
                        case "1":
                            Text_Z_rotation_J1.text = "J" + current.GetName() + "-Z: " + current.transform.localEulerAngles.z.ToString("0.00");
                            break;
                        case "2":
                            Text_Z_rotation_J2.text = "J" + current.GetName() + "-Y: " + current.transform.localEulerAngles.y.ToString("0.00");
                            break;
                        case "3":
                            Text_Z_rotation_J3.text = "J" + current.GetName() + "-Z: " + current.transform.localEulerAngles.z.ToString("0.00");
                            break;
                        case "4":
                            Text_Z_rotation_J4.text = "J" + current.GetName() + "-Z: " + current.transform.localEulerAngles.z.ToString("0.00");
                            break;
                        case "5":
                            Text_Z_rotation_J5.text = "J" + current.GetName() + "-Z: " + current.transform.localEulerAngles.z.ToString("0.00");
                            break;
                        default:
                            Text_Z_rotation_J0.text = "J" + current.GetName() + "-Y: " + current.transform.localEulerAngles.y.ToString("0.00");
                            break;
                    }

                    current = current.GetChild();
                }
            }
        }
    }
    void RotateJoint(ref Joint current, float angle)
    {
        current.Rotate(-angle * m_rate);
        if (current.GetName()=="1" || current.GetName() == "2")
        {
            if (current.IsJoinIn_GOOD_Rotation())
            {
                Text_Z_rotation_J0.text = "Jest git";
                //current.Rotate(-angle * m_rate);                                                          //wczesniej zrobiono ruch zeby sprawdzic czy nie przedobrzyl
            }
            else
            {
                Text_Z_rotation_J0.text = "Lipa";
                current.Rotate(angle * m_rate);                                                             //jezeli przedobrzy to cofnij ruch
            }
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
