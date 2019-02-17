using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class flickercontroll : MonoBehaviour {

    public GameObject ball; //assign the game object sphere or what ever you want to blink
    double timer;
    double frq;
    public bool onoff;
    

private void FixedUpdate()
{
        
    }

    void Update()
    {
        
        if (ball.name == "Front")
        {
            frq = flickerFrqVar.top;
        }
        else if (ball.name == "Back")
        {
            frq = flickerFrqVar.bottom;
        }
        else if (ball.name == "Left")
        {
            frq = flickerFrqVar.left;
            print("left " + frq);
        }
        else if (ball.name == "Right")
        {
            frq = flickerFrqVar.right;
            print("right " + frq);
        }
        Sphere_blink();
    }
    /*
        void Sphere_blink()
        {
            if (Time.time > timer)
            {
                timer = Time.time + 1/frq;
                onoff = !onoff;
                ball.GetComponent<Renderer>().enabled = onoff;

            }//Time.time > timer ends

        }//sphere_blink ends    //in c# call the function  sphere_blink() where ever you want the sphere to blink  

    */


    void Sphere_blink()
    {
        float freq = (float) frq;

        float a = Mathf.Sin(Time.time * 2.0f* 3.14159265358979f * freq);

        if (a < 0)
        {
            onoff = false;
        }
        else
        {
            onoff = true;
        }
        

         ball.GetComponent<Renderer>().enabled = onoff;

    }//sphere_blink ends    //in c# call the function  sphere_blink() where ever you want the sphere to blink  



}
