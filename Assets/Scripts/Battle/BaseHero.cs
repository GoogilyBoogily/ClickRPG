using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;

public class Hero {
	public string name;
	public string description;
	public float health;
	public float strength;
	public float armor;
	public float accuracy;
	public float evasion;
	public float critChance;
	public float critMultiplier;
	public float blockChance;
	public float blockMultiplier;
	public float finesse;
	public float attackSpeed;
	public float armorPen;
	public float dexterity;
	public float tenacity;
	public float resolve;
	public float basicAttackCooldown;

	public string target;

	public List<Ability> abilities;
}
