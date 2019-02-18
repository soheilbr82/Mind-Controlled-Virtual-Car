using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerFrqVar : MonoBehaviour {

    public static double left = 1;
    public static double right = 1;
    public static double top = 1;
    public static double bottom = 1;
    public double pleft;
    public double pright;
    public double ptop;
    public double pbottom;
    // Use this for initialization
    void Start () {
        left = pleft;
        right = pright;
        top = ptop;
        bottom = pbottom;
        print("pleft " + pleft);
        print("pright " + pright);
    }
}
