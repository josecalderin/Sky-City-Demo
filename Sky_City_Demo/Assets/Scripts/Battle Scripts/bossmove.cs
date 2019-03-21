using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmove : MonoBehaviour {
    public Transform meteorObj;
    public Transform exploObj;
    public Transform hiteffObj;

    public float bossHP = 150;
    public float bossAttPow = 20;
    public int heroAttacked = 0;
    public int bossXP = 100;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        

        
        //if (Input.GetKeyDown("5"))
        if ((GameFlow.whichTurn == 3) && (gameObject.name == "Boss"))
        {
            
            GetComponent<Transform>().position = new Vector2(-1.53f, .23f);
            StartCoroutine(returnHero());
            GameFlow.whichTurn = 4;
        }
        if ((GameFlow.whichTurn == 5) && (gameObject.name == "Boss2"))
        {

            GetComponent<Transform>().position = new Vector2(-1.53f, .23f);
            StartCoroutine(returnHero());
            GameFlow.whichTurn = 1;
        }
        if ((GameFlow.damageDisplay == "y") && (gameObject.name == GameFlow.selectedBoss))
        {
            bossHP -= GameFlow.currentDamage;
            Instantiate(hiteffObj, transform.position, hiteffObj.rotation);
            Debug.Log(gameObject.name+ " "+bossHP);
            GameFlow.damageDisplay = "n";
        }
        if (bossHP <= 0)
        {
            GameFlow.heroTotalXP += bossXP;
            GameFlow.suppTotalXp += bossXP;
            Debug.Log("Hero XP " + GameFlow.heroTotalXP + " Supp XP " + GameFlow.heroTotalXP);
            Destroy(gameObject);
        }



        //if (Input.GetKeyDown("7"))
        //{
        //    Instantiate(meteorObj, new Vector2(-4f, 5.17f), meteorObj.rotation);
        //    StartCoroutine(returnHero());
        //}
        //if (Input.GetKeyDown("8"))
        //{
        //    Instantiate(exploObj, new Vector2(-4.49f, .5f), exploObj.rotation);
        //    StartCoroutine(returnHero());
        //}
    }
    IEnumerator returnHero()
    {
        yield return new WaitForSeconds(1);

        if (GameFlow.whichTurn == 4)
        {
            GameFlow.whichTurn = 5;
        }
        heroAttacked = Random.Range(1, 3);

        if (GameFlow.heroStatus == "dead")
        {
            heroAttacked = 2;
        }
        if (GameFlow.suppStatus == "dead")
        {
            heroAttacked = 1;
        }

        if(heroAttacked == 1)
        { 
            herokey.heroHP -= bossAttPow;
            Instantiate(hiteffObj, new Vector2(-4.45f, 1.17f), hiteffObj.rotation);
            Debug.Log("Hero HP " + herokey.heroHP);
        }
        else
        {
            suppmove.suppHP -= bossAttPow;
            Instantiate(hiteffObj, new Vector2(-4.45f, -2.1f), hiteffObj.rotation);
            Debug.Log("Supp HP " + suppmove.suppHP);
        }


        if (gameObject.name == "Boss")
        {
            GetComponent<Transform>().position = new Vector2(6.5f, 1.17f);
        }
        if (gameObject.name == "Boss2")
        {
            GetComponent<Transform>().position = new Vector2(6.5f, -2.1f);
        }


    }
    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        GameFlow.selectedBoss = gameObject.name;
    }
}
