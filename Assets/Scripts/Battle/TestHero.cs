using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;

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

        //Targeting?

		target = "";

        //Ability list

        abilities = new List<Ability>();

        abilities.Add(new TestAbility1());
        abilities.Add(new TestAbility2());
        

	} // end constructor
}
