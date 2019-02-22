using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowmove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector2(3, 0);
        Destroy(gameObject, 3.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
