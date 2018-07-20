using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPP_Front : MonoBehaviour {

    public GameObject ball; //assign the game object sphere or what ever you want to blink
    public double timer;
    public double frq;
    public bool onoff;
    void Update()
    {
        Sphere_blink();
    }

    void Sphere_blink()
    {
        if (Time.time > timer)
        {

            timer = Time.time + 1 / frq;
            onoff = !onoff;
            ball.GetComponent<Renderer>().enabled = onoff;

        }

    }
}
