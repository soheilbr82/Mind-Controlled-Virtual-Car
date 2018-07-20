using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class logRecord : MonoBehaviour {

    private float startTime;
    private float lastTime;
    private int leftCurb;
    private int rightCurb;
    public string path;
    private string buffer;
    public static int leftCurbHits = 0;
    public static int rightCurbHits = 0;
    public static int cpNum = -1;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        lastTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        buffer = "";
        float top = UDPObj.topNum;
        float bottom = UDPObj.bottomNum;
        float left = UDPObj.leftNum;
        float right = UDPObj.rightNum;

        float ct = Time.time - startTime;
        string cmin = ((int)ct / 60).ToString();
        string csec = (ct % 60).ToString("f2");

        float et = Time.time - lastTime;
        string emin = ((int)et / 60).ToString();
        string esec = (et % 60).ToString("f2");

        if(top > 0)
        {
            buffer = "Time: " + cmin + ":" + csec + ", received control signal: Front, " +
                "speed: " + top + ", elapsed time: " + emin + ":" + esec + ", travelled distance: " +
                distance.distanceTravelled + ", hit left curb: " + leftCurbHits + ", hit right curb: " +
                rightCurbHits + ", max check point number: " + cpNum + ".";
            lastTime = Time.time;
            WriteToFile(buffer);
        }else if(bottom > 0)
        {
            buffer = "Time: " + cmin + ":" + csec + ", received control signal: Back, " +
                "speed: " + bottom + ", elapsed time: " + emin + ":" + esec + ", travelled distance: " +
                distance.distanceTravelled + ", hit left curb: " + leftCurbHits + ", hit right curb: " +
                rightCurbHits + ", max check point number: " + cpNum + ".";
            lastTime = Time.time;
            WriteToFile(buffer);
        }else if(left > 0)
        {
            buffer = "Time: " + cmin + ":" + csec + ", received control signal: Left, " +
                "speed: " + left + ", elapsed time: " + emin + ":" + esec + ", travelled distance: " +
                distance.distanceTravelled + ", hit left curb: " + leftCurbHits + ", hit right curb: " +
                rightCurbHits + ", max check point number: " + cpNum + ".";
            lastTime = Time.time;
            WriteToFile(buffer);
        }else if(right > 0)
        {
            buffer = "Time: " + cmin + ":" + csec + ", received control signal: Right, " +
                "speed: " + right + ", elapsed time: " + emin + ":" + esec + ", travelled distance: " +
                distance.distanceTravelled + ", hit left curb: " + leftCurbHits + ", hit right curb: " +
                rightCurbHits + ", max check point number: " + cpNum + ".";
            lastTime = Time.time;
            WriteToFile(buffer);
        }

    }

    void WriteToFile(string n)
    {
        StreamWriter TextFile = new StreamWriter(path);

        TextFile.WriteLine(n);

        TextFile.Close();
    }
}
