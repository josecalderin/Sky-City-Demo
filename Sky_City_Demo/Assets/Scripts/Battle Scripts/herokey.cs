using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herokey : MonoBehaviour {

    public Transform shadowballObj;
    public Transform meteorObj;
    public Transform damtextObj;



    public static float heroHP = 120;
    public static float heroMaxHP = 120;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (heroHP <= 0)
        {
            GameFlow.heroStatus = "dead";
            Debug.Log(GameFlow.heroStatus);
            Destroy(gameObject);

        }

        if (((Input.GetKeyDown("1"))||(GameFlow.attButPressed == "y")) && (GameFlow.whichTurn == 1))
        {

            GameFlow.currentDamage = 60;
            GameFlow.attButPressed = "n";
            GetComponent<Transform>().position = new Vector2(-3.8f, -.42f);
            Instantiate(shadowballObj, new Vector2(-3f, -.8f), shadowballObj.rotation);
            StartCoroutine(returnHero());   
            if (GameFlow.suppStatus == "dead")
            {
                GameFlow.whichTurn = 3;
            }
            else { 
            GameFlow.whichTurn = 2;
                }

        }
    }
    IEnumerator returnHero()
    {

        yield return new WaitForSeconds(1);
        GetComponent<Transform>().position = new Vector2(-4.45f, 1.17f);
        yield return new WaitForSeconds(2f);
        Instantiate(damtextObj, new Vector2(5.65f, 2f), damtextObj.rotation);
        GameFlow.damageDisplay = "y";
         
    }
}