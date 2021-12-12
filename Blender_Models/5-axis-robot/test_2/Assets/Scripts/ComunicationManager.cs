using System.Collections;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class ComunicationManager : MonoBehaviour
{
    public Text Text_Z_rotation_J0;
    public Text Text_Z_rotation_J1;
    public Text Text_Z_rotation_J2;
    public Text Text_Z_rotation_J3;
    public Text Text_Z_rotation_J4;
    public Text Text_Z_rotation_J5;


    private SerialPort serialPort1;

    // Start is called before the first frame update
    void Start()
    {
        serialPort1 = new SerialPort();
        serialPort1.PortName = "COM7";
        serialPort1.BaudRate = Convert.ToInt32(9600);
        serialPort1.Open();
        Invoke("SendData", 2f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SendData()
    {
        if (serialPort1.IsOpen)
        {
            serialPort1.Write("" +
                 "q1:"+ _getRotation(Text_Z_rotation_J1.text) + 
                ";q2:"+ _getRotation(Text_Z_rotation_J2.text) + 
                ";q3:"+ _getRotation(Text_Z_rotation_J3.text) + 
                ";q4:"+ _getRotation(Text_Z_rotation_J4.text) + 
                ";q5:"+ _getRotation(Text_Z_rotation_J5.text) + 
                ";" + "\n");
        }
        Invoke("SendData", 0.1f);

    }

    string _getRotation(string text)
    {
        bool corData = false;
        string ret = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (corData)
                ret += text[i];

            if (text[i] == ' ')
                corData = true;

            if (text[i] == ',')
            {
                //if (int.Parse(ret) > 180)
                //{
                //    ret = "180";
                //}
                return ret;
            }
        }
        return ret;
    }
}
