using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour {

	public void changemenuscene(string scenename)
    {
        //Application.LoadLevel(scenename);
        distance.distanceTravelled = 0;
        SceneManager.LoadScene(scenename);
    }
}
