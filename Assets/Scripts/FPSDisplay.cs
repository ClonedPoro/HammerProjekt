using UnityEngine;
using System.Collections;
using System.IO;
//using Microsoft.Data.Analysis;
using System;
using System.Collections.Generic;



public class FPSDisplay : MonoBehaviour
{
    float deltaTime_fps = 0.0f;
    // float[,] data_list = new float[inf,3];
    //List<float> data_list = new List<float>();
    //List<float> dt_list = new List<float>();

    float[] deltaTimes;
    float[] fps;

    //DataFrameColumn[] columns =
    //{
    //    new PrimitiveDataFrameColumn<float>("Delta Time", deltaTimes),
    //   new PrimitiveDataFrameColumn<float>("FPS", fps),
    //};

    //DataFrame df = new(columns);
    List<Int16> fps_list = new List<Int16>();
    List<double> timestamps = new List<double>();
    List<DateTime> date_list = new List<DateTime>();
    DateTime start = DateTime.UtcNow;
    void Update()
    {
        deltaTime_fps += (Time.unscaledDeltaTime - deltaTime_fps) * 0.1f;
        //dt_list.Add(deltaTime);
        DateTime end = DateTime.UtcNow;
        TimeSpan timespent = end - start;
        float fps = 1.0f / deltaTime_fps;

        
        //fulltime = deltaTime + fulltime;
        //data_list.Add(fps);
        Int16 fps_int = (Int16)Math.Round(fps);
        fps_list.Add(fps_int);
        timestamps.Add(timespent.TotalSeconds);
        //timestamps.Add(timestamps[timestamps.Count - 1] + deltaTime);
        date_list.Add(DateTime.Now);
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime_fps * 1000.0f;
        float fps = 1.0f / deltaTime_fps;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

    void OnDestroy()
    {
        //Debug.Log(data_list);
        
        string path = @"C:\Users\VR\Documents\GitHub\HammerProjekt\Output\FPS_test.csv";
        //string text = @"FPS Rate";

        //using (StreamWriter writer = new StreamWriter(path))
        using (StreamWriter sw = File.CreateText(path))
        /*{
            data_list.ForEach(data_list => writer.WriteLine(data_list));
            dt_list.ForEach(data_list => writer.WriteLine(dt_list));
        */
        {
            //timestamps.ForEach(timestamps => writer.WriteLine(timestamps));
            //fps_list.ForEach(fps_list => writer.WriteLine(fps_list));
            sw.WriteLine("DateTime; total_time; fps");
            for (int i = 0; i < fps_list.Count; i++)
            {
                //var line = String.Format("{0},{1}, {2}", date_list[i], timestamps[i], fps_list[i]);
                 
                sw.WriteLine(date_list[i].ToString() + ";" + timestamps[i].ToString() + ";" + fps_list[i].ToString());
                
            }
        }

    }
}
