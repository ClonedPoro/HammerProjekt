using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// MUSS mit Tisch/body_01 verknüpft werden!!
public class Tisch_Kalibrierung : MonoBehaviour
{
    // Definitions
    float x;
    float y;
    float z;
    float fx;
    float fy;
    float fz;

    string path = @"C:\Users\VR\Documents\GitHub\HammerProjekt\Output_test\Tisch_Kalibrierung.csv";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bitte drücke die t-Taste um die Tischhöhe zu kalibrieren.");

        StreamWriter sw = File.CreateText(path);
        sw.WriteLine("x; y; z; forward_x; forward_y; forward_z");
        sw.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
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

            Debug.Log("DONE. Die aktuelle Tischhöhe wurde eingelesen.");

            // update hight
            transform.position = transform.position + new Vector3(x, y, z);
            // QUELLE: https://docs.unity3d.com/ScriptReference/Transform-position.html
            // Rotation? 

            Debug.Log("DONE. Tischpositon wurde zu ... geändert");
        }
    }
}
