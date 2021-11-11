using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public LayerMask groundMask;
    public Transform groundCheck;
    private Vector3 velocity;
    private bool isGrounded;
    public float groundDistance = 0.4f;
    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = 9.81f ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime * Time.deltaTime / 2;
            controller.Move(velocity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


    }
}
