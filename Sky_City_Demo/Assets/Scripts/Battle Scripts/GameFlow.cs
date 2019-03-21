using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour {
    public static int whichTurn = 1;
    public static float currentDamage = 0;
    public static string damageDisplay = "n";
    public static string heroStatus = "okay";
    public static string suppStatus = "okay";
    public static int heroTotalXP = 0;
    public static int suppTotalXp = 0;

    public static string selectedBoss = "";
    public static string attButPressed = "n";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if ((whichTurn == 1) && (heroStatus == "dead"))
        {
            whichTurn = 2;
        }
        if ((whichTurn == 2) && (suppStatus == "dead"))
        {
            whichTurn = 1;
        }
    }
}
