using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;

public class TestHero : Hero {

	public TestHero() {
        name = "Sir Testalot";
		description = "I like butts. And testing.";
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

        abilities = new List<Ability>();

        abilities.add(new TestAbility1());
        abilities.add(new TestAbility2());
        

	} // end constructor
}
