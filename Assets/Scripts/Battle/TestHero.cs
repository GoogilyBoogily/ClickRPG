using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;

public class TestHero : BaseChampion {

	public TestHero() {
        name = "Test";
		description = "I like butts.";
		health = 1000;
		strength = 100;
		armor = 100;
		accuracy = 50;
		evasion = 50;
		critChance = 20;
		critMultiplier = 200;
		blockChance = 20;
		blockMultiplier = 50;
		finesse = 30;
		attackSpeed = 5;
		armorPen = 0;
		dexterity = 5;
		tenacity = 0;
		resolve = 0;
		basicAttackCooldown = 3;

		target = "";
	} // end constructor
}
