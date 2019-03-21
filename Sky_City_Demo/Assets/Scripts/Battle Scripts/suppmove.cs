using UnityEngine;
using System.Collections;

public class suppmove : MonoBehaviour
{
    public Transform waterObj;
    public Transform water2Obj;
    public Transform damtextObj;

    public static float suppHP = 90;
    public static float suppMaxHP = 90;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (suppHP <= 0)
        {
            GameFlow.suppStatus = "dead";
            Destroy(gameObject);
        }

        if (((Input.GetKeyDown("1")) || (GameFlow.attButPressed == "y")) && (GameFlow.whichTurn == 2))
        {
            GameFlow.currentDamage = 30;
            GameFlow.attButPressed = "yes";
            GetComponent<Transform>().position = new Vector2(-3.8f, -.42f);
            Instantiate(waterObj, new Vector2(-3f, -.8f), waterObj.rotation);
            StartCoroutine(returnHero());
            
        }
        //if (Input.GetKeyDown("6"))
        //{
        //    Instantiate(water2Obj, new Vector2(5.84f, -2.55f), water2Obj.rotation);
        //    StartCoroutine(returnHero());
        //}

    }
    IEnumerator returnHero()
    {
        yield return new WaitForSeconds(2.5f);
        Instantiate(damtextObj, new Vector2(5.65f, 2f), damtextObj.rotation);
        yield return new WaitForSeconds(1);
        GameFlow.damageDisplay = "y";
        GetComponent<Transform>().position = new Vector2(-4.45f, -2.1f);
        yield return new WaitForSeconds(1.5f);
        GameFlow.whichTurn = 3;
    }
}
