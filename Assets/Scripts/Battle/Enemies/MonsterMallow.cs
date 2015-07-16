using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Abilities;


public class MonsterMallow : Enemy
{

    public MonsterMallow(){

        name = "Monster Mallow";
        description = "OH JESUS LOOK OUT IT'S A REALLY BIG MALLOW.";

        //Enemy Stats

        strength = 50;
        dexterity = 10;
        physicalPenetration = 0;
        physicalAccuracy = 0;
        physicalFinesse = 0;
        physicalCritChance = 0;
        physicalCritMultiplier = 0;

        armor = 0;
        physicalEvasion = 0;
        physicalBlockChance = 0;
        physicalBlockMultiplier = 0;

        wisdom = 0;
        celerity = 0;
        magicalPenetration = 0;
        magicalAccuracy = 0;
        magicalFinesse = 0;
        magicalCritChance = 0;
        magicalCritMultiplier = 0;

        spirit = 0;
        magicalEvasion = 0;
        magicalBlockChance = 0;
        magicalBlockMultiplier = 0;

        health = 1000;
        healthRegen = 5;
        tenacity = 30;
        resolve = 0;


        currentAbilityType = AbilityTypes.Null;
        currentBattleState = BattleStates.Wait;


        //Targeting?

        target = "";

        


    } // end constructor
}
