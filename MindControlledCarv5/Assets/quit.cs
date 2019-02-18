using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        Application.Quit();
    }
}
