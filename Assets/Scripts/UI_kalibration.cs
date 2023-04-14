using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_kalibration : MonoBehaviour
{
    public GameObject uiPanel;
    // Start is called before the first frame update
    void Start()
    {
        uiPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            uiPanel.SetActive(true);
        }
    }
}
