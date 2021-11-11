using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public bool DynamicView;
    public float mouseSensitivity = 300f;
    private float xRotation = 0f;
    public Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        DynamicView = false;
        //Cursor.lockState = CursorLockMode.Locked;                                                           //ukrywanie kursora
    }

    // Update is called once per frame
    void Update()
    {
        if (DynamicView)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
    public void ChangeDynamicView()
    {
        DynamicView = !DynamicView;
        if (!DynamicView)
        {
            transform.localRotation = Quaternion.Euler(0, 0f, 0f);
            playerBody.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
