using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEdited : MonoBehaviour
{
    public float keyDelay = 0.2f;
    private float timePassed = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;

		if (Input.GetAxisRaw("Horizontal") == 1 && timePassed >= keyDelay)//Right key
        {
            transform.Translate((Input.GetAxisRaw("Horizontal") - 0.9f), 0.0f, 0.0f);
            timePassed = 0f;
            
        }
        if (Input.GetAxisRaw("Horizontal") == -1 && timePassed >= keyDelay)//Left key
        {
            transform.Translate((Input.GetAxisRaw("Horizontal") + 0.9f), 0.0f, 0.0f);
            timePassed = 0f;
        }
		
        if (Input.GetAxisRaw("Vertical") == 1 && timePassed >= keyDelay)//UP key
        {
            transform.Translate(0f, (Input.GetAxisRaw("Vertical") - 0.9f), 0.0f);
            timePassed = 0f;
        }
		if (Input.GetAxisRaw("Vertical") == -1 && timePassed >= keyDelay)//Down key
        {
            transform.Translate(0f, (Input.GetAxisRaw("Vertical") + 0.9f), 0.0f);
            timePassed = 0f;

        }

    }
}
