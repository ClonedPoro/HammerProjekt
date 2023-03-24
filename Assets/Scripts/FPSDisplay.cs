using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.Data.Analysis;


public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;
    // float[,] data_list = new float[inf,3];
    //List<float> data_list = new List<float>();
    //List<float> dt_list = new List<float>();

    float[] deltaTimes;
    float[] fps;

    DataFrameColumn[] columns =
    {
        new PrimitiveDataFrameColumn<float>("Delta Time", deltaTimes),
        new PrimitiveDataFrameColumn<float>("FPS", fps),
    };

    DataFrame df = new(columns);

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        //dt_list.Add(deltaTime);

        float fps = 1.0f / deltaTime;
        //data_list.Add(fps);
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

    void OnDestroy()
    {
        Debug.Log(data_list);
        
        string path = @"C:\Users\VR\Documents\GitHub\HammerProjekt\Output\FPS_test.csv";
        //string text = @"FPS Rate";

        using (StreamWriter writer = new StreamWriter(path))
        {
            data_list.ForEach(data_list => writer.WriteLine(data_list));
            dt_list.ForEach(data_list => writer.WriteLine(dt_list));
        }
    }
}
