using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEventsRemote : MonoBehaviour {
	public Camera[] cams;

	public void FPP_Cam()
	{
		cams[0].enabled = true;
		cams[1].enabled = false;
		cams[2].enabled = false;
	}

	public void TPP_Cam()
	{
		cams[0].enabled = false;
		cams[1].enabled = true;
		cams[2].enabled = false;
	}

	public void Full_Cam()
	{
		cams[0].enabled = false;
		cams[1].enabled = false;
		cams[2].enabled = true;
	}
}
