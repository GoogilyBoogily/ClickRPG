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

        physicalPenetration = 0;
        physicalAccuracy = 0;
        physicalFinesse = 0;

        armor = 0;
        physicalEvasion = 0;
        physicalBlockChance = 0;
        physicalBlockMultiplier = 0;

        magicalPenetration = 0;
        magicalAccuracy = 0;
        magicalFinesse = 0;

        spirit = 0;
        magicalEvasion = 0;
        magicalBlockChance = 0;
        magicalBlockMultiplier = 0;

        maxHealth = 5000;
        healthRegen = 10;

        tenacity = 30;
        resolve = 0;


        currentAbilityType = Ability.AbilityTypes.Null;
        currentBattleState = BattleStates.Wait;


        //Ability List

        abilities = new List<Ability>(7);

        abilities.Add(new NullAbility());


    } // end constructor
}
