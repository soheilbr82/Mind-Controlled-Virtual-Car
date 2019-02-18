using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;

	void Start () {
        startTime = Time.time;
	}
	
	void Update () {
        float t = Time.time - startTime;

        string min = ((int)t / 60).ToString();
        string sec = (t % 60).ToString("f2");

        timerText.text = "Time: " + min + ":" + sec;
	}
}
