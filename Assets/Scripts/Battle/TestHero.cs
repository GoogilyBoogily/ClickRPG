using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using Heroes;

public class TestHero : Hero {

	public TestHero() {

        name = "Sir Testalot";
		description = "I like butts. And testing.";


        //Hero Stats

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
        mana = 500;
        manaRegen = 20;
        tenacity = 30;
        resolve = 0;

       
        //Variables to keep track of things (timers & counters)

        currentAbilityType = AbilityTypes.Null;
        currentBattleState = BattleStates.Initializing;


        //Ability list

        abilities = new List<Ability>(7);

        abilities.Add(new NullAbility());
        abilities.Add(new PunchBarrage());
        abilities.Add(new ChargePunch());


        //Variables to keep track of cooldowns

        abilityOneCooldownTimer = 0.0f;
        abilityTwoCooldownTimer = 0.0f;
        abilityThreeCooldownTimer = 0.0f;
        abilityFourCooldownTimer = 0.0f;
        abilityFiveCooldownTimer = 0.0f;
        abilitySixCooldownTimer = 0.0f;


        //Targeting?

        target = "";
        

	} // end constructor
}
