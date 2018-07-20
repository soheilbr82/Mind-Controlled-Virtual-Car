using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class disRecord : MonoBehaviour {
    public static int record = 0;
    public GameObject wall;
    public GameObject flag;
    public GameObject text;
    public GameObject nextCheckPoint;

    void OnTriggerEnter(Collider other)
    {
        record = (int)distance.distanceTravelled;
        logRecord.cpNum++;
        if (wall != null)
            wall.SetActive(false);
        if (flag != null)
            flag.SetActive(false);
        if (text != null)
            text.SetActive(false);
        if(nextCheckPoint != null)
            nextCheckPoint.SetActive(true);
}
}
