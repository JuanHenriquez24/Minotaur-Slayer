﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialConnection : MonoBehaviour
{
    
    SerialPort serialPort = new SerialPort("COM6", 9600);

    void Start()
    {
        serialPort.Open();

        serialPort.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string lecturaValor = serialPort.ReadLine();
                string[] valor = lecturaValor.Split(',');
            }
            catch
            {

            }
        }
    }
}