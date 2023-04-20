using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_check : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "hammerhammered")
        {
            Debug.Log("TEST");
        }
    }
}