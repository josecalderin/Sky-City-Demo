﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PlayerBattleController : Battler {

	// This is what contains everything.
	public GameObject CombatUIPanel;

    public GameObject MainCombatMenu;
    public GameObject MainCombatMenuTopButton;
    public GameObject MainCombatMenuSecondButton;

	public GameObject SpecialMoveMenu;
	public GameObject SpecialMoveMenuTopButton;
    public GameObject SpecialMoveMenuMiddleTopButton;

    bool choosing = false; //true if player currently choosing action

	void Start()
	{
		// Hides the panel containing all the combatui elements.
		CombatUIPanel.SetActive (false);
		SpecialMoveMenu.SetActive (false);

		// Will remain hidden until CombatUIPanel becomes active.
		MainCombatMenu.SetActive (true);
	}

    public override IEnumerator ChooseAction(Action Finish)
	{
        //this triggers the choice GUI
        CombatUIPanel.SetActive(true);

        //the next turn after using Cocoon, prevent attacking
        if(battleState.statusEffects.Exists(
            se => se.name == "Cocoon" && se.numberOfTurnsRemaining == 3))
        {
            MainCombatMenuTopButton.GetComponent<Button>().interactable = false;
            SpecialMoveMenuTopButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            MainCombatMenuTopButton.GetComponent<Button>().interactable = true;
            SpecialMoveMenuTopButton.GetComponent<Button>().interactable = true;
        }

        EventSystem.current.SetSelectedGameObject(null);
        if (!MainCombatMenu.activeSelf)
        {
            if (!SpecialMoveMenuTopButton.GetComponent<Button>().interactable)
            {
                EventSystem.current.SetSelectedGameObject(SpecialMoveMenuMiddleTopButton);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(SpecialMoveMenuTopButton);
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(MainCombatMenuTopButton);
        }

		choosing = true;
		yield return new WaitUntil (() => !choosing);
		choosing = false;
		CombatUIPanel.SetActive (false);

		// One second for the message to disappear.
		yield return new WaitForSeconds(1);

        GameObject enemy = GameObject.FindWithTag("Enemy");
        singleAttackTarget = enemy.transform.parent.gameObject.GetComponent<Battler>();

        Finish();
    }

	//triggered when player selects main combat menu's top button ("Attack")
	public void AttackButtonPress()
	{
        choosing = false;
        DoAction = BasicAttack;
	}

    //triggered when player selects main combat menu's bottom button ("Special Move")
	public void SpecialMoveButtonPress()
	{
		SpecialMoveMenu.SetActive (true);
		MainCombatMenu.SetActive (false);

        if (!SpecialMoveMenuTopButton.GetComponent<Button>().interactable)
        {
            EventSystem.current.SetSelectedGameObject(SpecialMoveMenuMiddleTopButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(SpecialMoveMenuTopButton);
        }  
	}

	//triggered when player selects special move menu's top button ("Reckless")
	public void SpecialMoveMenuTopButtonPress()
	{
		DoAction = SpecialMoveReckless;
		choosing = false;
	}

    //triggered when player selects special move menu's middle top button ("Cocoon")
    public void SpecialMoveMenuMiddleTopButtonPress()
	{
        DoAction = SpecialMoveCocoon;
        choosing = false;
	}

    //triggered when player selects the special move menu's middle bottom button ("Resolve")
    public void SpecialMoveMenuMiddleBottomButtonPress()
	{
		DoAction = SpecialMoveResolve;
		choosing = false;
	}

    //triggered when player selects special move menu's bottom button ("Back")
    public void SpecialMoveMenuBottomButtonPress()
	{
		MainCombatMenu.SetActive (true);
		SpecialMoveMenu.SetActive (false);

        if (MainCombatMenuTopButton.GetComponent<Button>().interactable == false)
        {
            EventSystem.current.SetSelectedGameObject(MainCombatMenuSecondButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(MainCombatMenuTopButton);
        }
	}

    // In Prototype 1, Reckless increases the player's damage by 100% for one turn and applies a
    // debuff to the player that increases the enemy's damage by 60% for two turns.
    IEnumerator SpecialMoveReckless(Action<bool, bool> Finish)
    {
        StartCoroutine(CombatUI.Instance.DisplayMessage("You launch a wild assault!", 1f));
        
        float damage = 2f * CalculateStandardDamage(singleAttackTarget);

        statusEffect se = new statusEffect("Reckless", true, false, 2, true);
        battleState.statusEffects.Add(se);

        //in place of animations, there is a 2 second wait
        yield return new WaitForSeconds(2);

        StartCoroutine(DealDamage(damage, Finish));
    }

    // In Prototype 1, Cocoon reduces the damage taken by the player by 50% for 3 turns but prevents
    // attacking for 1 turn.
    IEnumerator SpecialMoveCocoon(Action<bool, bool> Finish)
    {
        StartCoroutine(CombatUI.Instance.DisplayMessage("You prepare a strong defence.", 1f));
        
        statusEffect se = new statusEffect("Cocoon", true, false, 3, false);
        battleState.statusEffects.Add(se);

        //in place of animations, there is a 2 second wait
        yield return new WaitForSeconds(2);

        Finish(false, false);
    }

    // In Prototype 1, Resolve removes all debuffs and increases the player's defence by 3 for the
    // rest of the battle. This value was chosen because increasing defence by 9, which can be
    // achieved by using Resolve 3 times, leads to a decrease in damage of 36% due to the damage
    // formulas.
    IEnumerator SpecialMoveResolve(Action<bool, bool> Finish)
    {
        StartCoroutine(CombatUI.Instance.DisplayMessage("You gather your strength.", 1f));
        
        battleState.statusEffects.RemoveAll(se => se.debuff);
        battleState.defenceRating += 3;

        //in place of animations, there is a 2 second wait
        yield return new WaitForSeconds(2);

        Finish(false, false);
    }
}
