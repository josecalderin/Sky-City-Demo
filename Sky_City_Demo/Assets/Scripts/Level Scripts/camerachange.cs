using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerachange : MonoBehaviour {


    //public GameObject explosion;
    public Camera maincam;
    public Camera battlecam;
  




    void OnCollisionEnter2D(Collision2D coll)
    {
        // If a missile hits this object
        if (coll.gameObject.tag == "Player")
        {
            //maincam.gameObject.SetActive(false);
            //battlecam.gameObject.SetActive(true);
            maincam.enabled = false;
            battlecam.enabled = true;
            


            Debug.Log("HIT!");
        }
        print(coll);
    }
}