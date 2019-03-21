using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour {

    //public GameObject explosion;

    void OnCollisionEnter2D(Collision2D coll)
    {
        // If a missile hits this object
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("HIT!");
            }
        print(coll);
        }
    }
