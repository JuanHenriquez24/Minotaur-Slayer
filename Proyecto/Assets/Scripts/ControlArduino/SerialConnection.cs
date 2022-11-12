using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialConnection : MonoBehaviour
{
    
    SerialPort serialPort = new SerialPort("COM6", 115000);
    public string[] valor;
    private bool shaking;

    void Start()
    {
        serialPort.Open();

        serialPort.WriteTimeout = 200;

        shaking = FindObjectOfType<CameraScript>().shaking;
    }

    // Update is called once per frame
    void Update()
    {
        shaking = FindObjectOfType<CameraScript>().shaking;

        if (serialPort.IsOpen)
        {
           
            if (shaking)
            {
                serialPort.WriteLine("1");
            }
            
            
        }
    }
}
