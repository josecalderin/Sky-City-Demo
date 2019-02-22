﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ShapeshifterBruiser : Battler {

    public override IEnumerator ChooseAction(Action Finish)
    {
        System.Random r = new System.Random();
        
        GameObject player = GameObject.FindWithTag("Player");
        singleAttackTarget = player.transform.parent.gameObject.GetComponent<Battler>();
        List<statusEffect> playerStatusEffects = singleAttackTarget.battleState.statusEffects;

        if (playerStatusEffects.Exists(se => se.name == "Shapeshifter Toxin"))
        {
            DoAction = DoubleAttack;
        }
        else
        {
            int n = r.Next(3);

            if (n == 2) //33% of time
            {
                DoAction = Toxin;
            }
            else //66% of time
            {
                DoAction = BasicAttack;
            }
        }

        Finish();

        yield break;
    }


    //// Charges for one turn then attacks for three times standard damage the next turn. If attacked 
    //// during the charging turn, the attack is cancelled.

    //IEnumerator Charge(Action<bool, bool> Finish)
    //{
    //    StartCoroutine(CombatUI.Instance.DisplayMessage("The enemy begins setting up an attack.", 1f));

    //    statusEffect se = new statusEffect("Charged Up", true, false, 1, false);
    //    battleState.statusEffects.Add(se);

    //    //in place of animations, there is a 2 second wait
    //    yield return new WaitForSeconds(2);

    //    Finish(false, false);
    //}

    //IEnumerator ChargedAttack(Action<bool, bool> Finish)
    //{
    //    if (battleState.statusEffects.Exists(se => se.name == "Charged Up"))
    //    {
    //        StartCoroutine(CombatUI.Instance.DisplayMessage("The enemy hits you with a devastating blow!", 1f));

    //        battleState.statusEffects.RemoveAll(se => se.name == "Charged Up");

    //        StartCoroutine(StandardAttackWithMultiplier(3f, Finish));

    //        yield break;
    //    }
    //    else
    //    {
    //        Finish(false, false);
    //    }
    //}

    //deals twice as much damage as a regular attack
    IEnumerator DoubleAttack(Action<bool, bool> Finish)
    {
        StartCoroutine(CombatUI.Instance.DisplayMessage("The enemy strikes twice at lightning speed!", 1f));
        
        StartCoroutine(StandardAttackWithMultiplier(2f, Finish));

        yield break;
    }

    //applies a permanent debuff to the player, which allows the use of DoubleAttack
    IEnumerator Toxin(Action<bool, bool> Finish)
    {
        StartCoroutine(CombatUI.Instance.DisplayMessage(
            "The enemy releases shapeshifter toxin into the air.", 1f));
        
        statusEffect se = new statusEffect("Shapeshifter Toxin", false, false, 0, true);

        GameObject player = GameObject.FindWithTag("Player");
        singleAttackTarget = player.transform.parent.gameObject.GetComponent<Battler>();
        singleAttackTarget.battleState.statusEffects.Add(se);

        //in place of animations, there is a 2 second wait
        yield return new WaitForSeconds(2);

        Finish(false, false);
    }
}