using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Transform AnimObject;
    public float AnimSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            AnimObject.position = Vector3.MoveTowards(AnimObject.position,new Vector3(0, i, 0), Time.deltaTime * AnimSpeed);
        }
        for (int i = 0; i < 10; i++)
        {
            AnimObject.position = Vector3.MoveTowards(AnimObject.position, new Vector3(i, 0, 0), Time.deltaTime * AnimSpeed);
        }
        for (int i = 0; i < 10; i++)
        {
            AnimObject.position = Vector3.MoveTowards(AnimObject.position, new Vector3(9-i, 9-i, 0), Time.deltaTime * AnimSpeed);
        }
    }
}
