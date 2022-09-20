using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialConnection : MonoBehaviour
{
    
    SerialPort serialPort = new SerialPort("COM4", 115000);
    public string[] valor;

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
                valor = lecturaValor.Split(',');
            }
            catch
            {

            }
        }
    }
}
