using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlSwitch : MonoBehaviour {

	public void manualControl()
    {
        GetComponent<moving>().enabled = true;
        GetComponent<MindControl>().enabled = false;
    }

    public void mindControl()
    {
        GetComponent<moving>().enabled = false;
        GetComponent<MindControl>().enabled = true;
    }
}
