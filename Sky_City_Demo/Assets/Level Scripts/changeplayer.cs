using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeplayer : MonoBehaviour {
    public GameObject hero1;
    public GameObject hero2;
    // Use this for initialization
    void OnCollisionEnter2D(Collision2D coll)
    {
        // If a missile hits this object
        if (coll.gameObject.tag == "Player")
        {
            hero1.SetActive(false);
            hero2.SetActive(true);
        }
    }
}
