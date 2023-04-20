using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Controllertable_coordinates : MonoBehaviour
{
    int time = 0;
    int interval = 10;
    List<double> timestamps = new List<double>();
    DateTime start = DateTime.UtcNow;
    string path = @"C:\Users\VR\Documents\GitHub\HammerProjekt\Output_test\Controllertable_coordinates.csv";
    // Start is called before the first frame update
    void Start()
    {

        StreamWriter sw = File.CreateText(path);
        sw.WriteLine("timediff; x; y; z; forward_x; forward_y; forward_z");
        sw.Close();
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
            //aktuell nur Zeitdifferenzen; evtl. später noch timestamps
            sw.WriteLine(timespent.TotalSeconds + ";" + x + ";"+ y + ";" + z + ";" + transform.forward.x + ";" + transform.forward.y + ";" + transform.forward.z);
            sw.Close();
            Debug.Log("write to file");
            time = 0;
        }
        else
            time++;
    }
}
