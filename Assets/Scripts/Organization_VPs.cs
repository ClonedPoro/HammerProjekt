using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class Organization_VPs : MonoBehaviour
{
    string dir = @"C:\Users\VR\Documents\GitHub\HammerProjekt\Output\";
    // Start is called before the first frame update
    void Start()
    {
        string[] paths = { dir, "current_VP_path.txt" };
        string VP_path = File.ReadAllText(Path.Combine(paths));
        string VP_num = Regex.Match(VP_path, @"\d+").Value;
        Debug.Log("This is VP number: " + VP_num);

        if (!Directory.Exists(VP_path))
        {
            DirectoryInfo di = Directory.CreateDirectory(VP_path);
            directory_setup(@"position01\", VP_path);
            directory_setup(@"position02\", VP_path);
            directory_setup(@"position03\", VP_path);
            directory_setup(@"position04\", VP_path);
            directory_setup(@"position05\", VP_path);
            directory_setup(@"position06\", VP_path);
        }
    }
    void directory_setup(string position, string VP_path)
    {
        string[] VP_dir_pos1 = { VP_path.ToString(), position };
        string VP_dir_pos1_combined = Path.Combine(@VP_dir_pos1);
        Directory.CreateDirectory(VP_dir_pos1_combined);
        string[] VP_dir_pos1_series1 = { VP_dir_pos1_combined.ToString(), @"series01\" };
        Directory.CreateDirectory(Path.Combine(@VP_dir_pos1_series1));
        string[] VP_dir_pos1_series2 = { VP_dir_pos1_combined.ToString(), @"series02\" };
        Directory.CreateDirectory(Path.Combine(@VP_dir_pos1_series2));
        string[] VP_dir_pos1_series3 = { VP_dir_pos1_combined.ToString(), @"series03\" };
        Directory.CreateDirectory(Path.Combine(@VP_dir_pos1_series3));
    }

}
