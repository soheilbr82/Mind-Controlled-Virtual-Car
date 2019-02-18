using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distance : MonoBehaviour {
    public static float distanceTravelled = 0;
    public static int dis = -1;
    Vector3 lastPosition;
    public Text speedText;


    void Start()
    {
        lastPosition = transform.position;
    }


    void Update()
    {
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        if (dis != -1)
        {
            distanceTravelled = dis;
            dis = -1;
        }

        if (speedText != null)
            speedText.text = "Distance: " + (int)distanceTravelled + " m";
    }
}
