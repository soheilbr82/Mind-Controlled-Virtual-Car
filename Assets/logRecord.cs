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
    StreamWriter TextFile;

    // Use this for initialization
    void Start () {
        TextFile = new StreamWriter(path);
        WriteToFile("Time   Control signal   Speed   Elapsed time   Travelled distance   Left curb   Right curb   Max check point");
        startTime = Time.time;
        lastTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        buffer = "";
        float direction = UDPObj.direction;
        //float bottom = UDPObj.bottomNum;
        //float left = UDPObj.leftNum;
        //float right = UDPObj.rightNum;

        float ct = Time.time - startTime;
        string cmin = ((int)ct / 60).ToString();
        string csec = (ct % 60).ToString("f2");

        float et = Time.time - lastTime;
        string emin = ((int)et / 60).ToString();
        string esec = (et % 60).ToString("f2");

        if(direction == 3)
        {
            buffer = cmin + ":" + csec + " | Front | " + direction + " | " + emin + ":" + esec + " | " +
                distance.distanceTravelled + " | " + leftCurbHits + " | " + rightCurbHits + " | " + 
                cpNum + " | ";
            lastTime = Time.time;
            WriteToFile(buffer);
        }else if(direction == 4)
        {
            buffer = cmin + ":" + csec + " | Back | " + direction + " | " + emin + ":" + esec + " | " +
                distance.distanceTravelled + " | " + leftCurbHits + " | " + rightCurbHits + " | " +
                cpNum + " | ";
            lastTime = Time.time;
            WriteToFile(buffer);
        }else if(direction == 1)
        {
            buffer = cmin + ":" + csec + " | Left | " + direction + " | " + emin + ":" + esec + " | " +
                distance.distanceTravelled + " | " + leftCurbHits + " | " + rightCurbHits + " | " +
                cpNum + " | ";
            lastTime = Time.time;
            WriteToFile(buffer);
        }else if(direction == 2)
        {
            buffer = cmin + ":" + csec + " | Right | " + direction + " | " + emin + ":" + esec + " | " +
                distance.distanceTravelled + " | " + leftCurbHits + " | " + rightCurbHits + " | " +
                cpNum + " | ";
            lastTime = Time.time;
            WriteToFile(buffer);
        }
        else if (direction == 0)
        {
            buffer = cmin + ":" + csec + " | Stop | " + direction + " | " + emin + ":" + esec + " | " +
                distance.distanceTravelled + " | " + leftCurbHits + " | " + rightCurbHits + " | " +
                cpNum + " | ";
            lastTime = Time.time;
            WriteToFile(buffer);
        }

    }

    void WriteToFile(string n)
    {
        TextFile.WriteLine(n);

        TextFile.Close();
    }
}
