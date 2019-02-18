using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display : MonoBehaviour {

	// Use this for initialization
	void Start () {

		for (int i = 0; i < Display.displays.Length; i++)
			//Display.displays[i].Activate(1920,1200,60);
		Display.displays[0].Activate(1920,1080,60);
		Display.displays[1].Activate(1920,1080,60);
		
	}

}
