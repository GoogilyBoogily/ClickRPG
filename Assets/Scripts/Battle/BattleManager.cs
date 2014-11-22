using UnityEngine;
using System.Collections;
using BattleObjects;

public class BattleManager : MonoBehaviour {
	// Init the player and enemy objects
	BattleObject heroObject = new BattleObject();
	BattleObject enemyObject = new BattleObject();

	// Creates and initializes a new Queue.
	Queue battleQueue = new Queue();

	// Use this for initialization
	void Start() {
		heroObject.type = "hero";
		heroObject.target = "enemy";

		enemyObject.type = "enemy";
		enemyObject.target = "hero";

		// Init hero stats...
		heroObject.health = 1000;
		heroObject.strength = 100;
		heroObject.armor = 100;
		heroObject.accuracy = 5;
		heroObject.evasion = 5;
		heroObject.critChance = 20;
        heroObject.critMultiplier = 200;
		heroObject.blockChance = 20;
        heroObject.blockMultiplier = 50;
		heroObject.attackSpeed = 5;
		heroObject.armorPen = 0;
		heroObject.dexterity = 5;
		heroObject.basicAttackCooldown = 5;

		// Init enemy stats...
		enemyObject.health = 1000;
		enemyObject.strength = 100;
		enemyObject.armor = 100;
		enemyObject.accuracy = 2;
		enemyObject.evasion = 2;
		enemyObject.critChance = 10;
        enemyObject.critMultiplier = 300;
		enemyObject.blockChance = 10;
        enemyObject.blockMultiplier = 80;
		enemyObject.attackSpeed = 2;
		enemyObject.armorPen = 0;
		enemyObject.dexterity = 2;
		enemyObject.basicAttackCooldown = 7;


		// void InvokeRepeating(string methodName, float time, float repeatRate);
		// Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
		InvokeRepeating("DoFight", 0, 5);
	}  // end Start()

	// Update is called once per frame
	void Update() {
		
	}  // end Update()

	// Goes through everyone in the attack queue and does their basic attacking phase
	void DoFight() {
		battleQueue.Enqueue(heroObject);
		battleQueue.Enqueue(enemyObject);

		while(battleQueue.Count > 0) {
			Attack((BattleObject)battleQueue.Dequeue());
		}	// end while
	}	// end DoFight()

	// Takes in the attacker and defender and computes damage done
    void Attack(BattleObject attacker) {
		BattleObject defender;

		if(attacker.type == "hero") {
			defender = enemyObject;
        } else {
			defender = heroObject;
		}	// end else/if

		print("Attacker: " + attacker.type + " -- Defender: " + defender.type);

		// Do battle algorithm stuff here

        var missCheck = Random.Range(1, 100);

        if (missCheck >= (100 - (defender.evasion - attacker.accuracy))) {
            print("Miss!");
            return;
            
        }   //end if

        float damage = attacker.strength;

        int block = 0;
        int crit = 0;

        var blockCheck = Random.Range(1, 100);
        var critCheck = Random.Range(1, 100);

        /*I thought it might make sense to have these outside the if statement, in case we have any 
        reason to use them elsewhere.I figured if the "block" variable was only found in the 
        "if" statement, it would get messy if something checked for it and it didn't exist.*/


        if (blockCheck <= defender.blockChance) {
            print("Blocked!");
            damage *= (1-(defender.blockMultiplier/100));
            attacker.armorPen /= 2;
            block = 1;

        }   //end if

        /*block chance and initial block effects. Later damage will be affected by
        block reduction, which is a stat that isn't initialized yet so i won't touch it. */


        if (block == 0 && critCheck <= attacker.critChance) {
            print("Critical Strike!");
            damage *= (attacker.critMultiplier/100);
            attacker.armorPen *= 2;
            crit = 1;

        }   //end if
            
        /*crit chance and initial crit effects. Same thing as block, eventually we'll
        have crit damage but we'll worry about that later. */

        defender.armor *= (1 - (attacker.armorPen/100));
        damage *= (100 / (100 + defender.armor));

        print("Damage dealt: " + damage);

		defender.health -= damage;

		print("Defender health after damage: " + defender.health);

		print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	}	// end Attack()

}  // end class
