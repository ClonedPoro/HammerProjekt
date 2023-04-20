using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HMD_Kalibrierung : MonoBehaviour
{
    // Definitions
    float x;
    float y;
    float z;
    float fx;
    float fy;
    float fz;

    string path = @"C:\Users\VR\Documents\GitHub\HammerProjekt\Output_test\HMD_Kalibrierung.csv";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bitte drücke die v-Taste um das Vive-HMD zu kalibrieren.");

        StreamWriter sw = File.CreateText(path);
        sw.WriteLine("x; y; z; forward_x; forward_y; forward_z");
        sw.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
            fx = transform.forward.x;
            fy = transform.forward.y;
            fz = transform.forward.z;

            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(x + ";" + y + ";" + z + ";" + fx + ";" + fy + ";" + fz);
            sw.Close();

            Debug.Log("DONE. Die aktuelle Vive-HMD position wurde eingelesen.");
        }
    }
}
