using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerSwitch : MonoBehaviour {

    public GameObject[] flickers;

    public void FPP_F()
    {
        flickers[0].SetActive(true);
        flickers[1].SetActive(false);
        flickers[2].SetActive(false);
    }

    public void TPP_F()
    {
        flickers[0].SetActive(false);
        flickers[1].SetActive(true);
        flickers[2].SetActive(false);
    }

    public void FULL_F()
    {
        flickers[0].SetActive(false);
        flickers[1].SetActive(false);
        flickers[2].SetActive(true);
    }
}
