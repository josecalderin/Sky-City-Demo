using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lala : MonoBehaviour {
    public Camera maincam;
    public Camera battlecam;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("2"))
        {
            maincam.enabled = false;
            battlecam.enabled = true;
        }

    }
   
}
