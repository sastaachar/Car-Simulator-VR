using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class DataUpload : MonoBehaviour
{


    public string IP;  // define in init
    public int port;  // define in init

    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;

    public GameObject streering;
    string direction;

    // Use this for initialization
    void Start()
    {
        print("UDPSend.init()");

      

        // ----------------------------
        // create the connection
        // ----------------------------
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();

        // status
        print("Sending to " + IP + " : " + port);
        print("Testing: nc -lu " + IP + " : " + port);

        
    }

    // Update is called once per frame
    void Update()
    {
        //grabber object to check which han is grabbed
        OVRGrabbable sn = gameObject.GetComponent<OVRGrabbable>();

        //if not grabbed move back to initial
       
        if (!sn.isGrabbed)
        {
            //dont drive
            sendData("stop");
        }
        else
        {
            //if driving give the angles (its along the z axis)
            float turnAngle = transform.eulerAngles.z;

            if (OVRInput.Get(OVRInput.Button.One))
            {
                //drive no turn 
                sendData("forward");
            }
            else if (OVRInput.Get(OVRInput.Button.Three))
            {
                //reverse 
                sendData("reverse");
            }
            else
            {
                //turn left 
                if (sn.getName.name.ToString() == "CustomHandLeft")
                {
                    sendData("left");
                }
                else
                {
                    sendData("right");
                }
            }
        }
    }

    //funtion to send data
    private void sendData(string message)
    {
        try
        {
            // Convert the message to UTF-8 and store in a bytes array
            byte[] data = Encoding.UTF8.GetBytes(message);

            // send data to the created client
            print(message+"\n");
            client.Send(data, data.Length, remoteEndPoint);

        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }
}

