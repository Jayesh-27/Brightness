using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

public class UDPSender : MonoBehaviour
{
    public string esp8266IP; // IP address of the ESP8266
    public int esp8266Port; // Port number on the ESP8266
    public int myValue;
    public Slider slider;


    private UdpClient udpClient;

    void Start()
    {
        udpClient = new UdpClient();
    }

    void Update()
    {
        // Example: Send the value of a variable named 'myValue' to ESP8266

        SendIntToESP8266(myValue);
        myValue = (int)slider.value;
        
    }

    void SendIntToESP8266(int value)
    {
        byte[] data = System.BitConverter.GetBytes(value);
        udpClient.Send(data, data.Length, esp8266IP, esp8266Port);
        Debug.Log("Data sent");
    }
}