using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Tracker_coordinates : MonoBehaviour
{
    int time = 0;
    int interval = 1;
    List<double> timestamps = new List<double>();
    DateTime start = DateTime.UtcNow;
    string path = @"C:\Users\VR\Documents\GitHub\HammerProjekt\Output_test\Tracker_coordinates.csv";
    bool isColliding = false;
    // Start is called before the first frame update
    void Start()
    {

        StreamWriter sw = File.CreateText(path);
        sw.WriteLine("timediff; x; y; z; forward_x; forward_y; forward_zM; collision");
        sw.Close();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hammerhammered")
        {
            //Debug.Log("TEST");
            isColliding = true;
            //print("This works too");
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "hammerhammered")
        {
            isColliding = false;
        }   
    }
    // Update is called once per frame
    void Update()
    {
        if (time > interval)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float fx = transform.forward.x;
            float fz = transform.forward.z;
            DateTime end = DateTime.UtcNow;
            TimeSpan timespent = end - start;
            StreamWriter sw = File.AppendText(path);
            if (isColliding == true)
            {
                sw.WriteLine(timespent.TotalSeconds + ";" + x + ";" + y + ";" + z + ";" + transform.forward.x + ";" + transform.forward.y + ";" + transform.forward.z + ";" + 1);
            }
            else
            {
                sw.WriteLine(timespent.TotalSeconds + ";" + x + ";" + y + ";" + z + ";" + transform.forward.x + ";" + transform.forward.y + ";" + transform.forward.z + ";" + 0);
            }
            sw.Close();
            // Debug.Log("write to file");
            time = 0;
        }
        else
            time++;
    }
}

