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
		heroObject.accuracy = 50;
		heroObject.evasion = 50;
		heroObject.critChance = 20;
        heroObject.critMultiplier = 200;
		heroObject.blockChance = 20;
        heroObject.blockMultiplier = 50;
        heroObject.finesse = 30;
		heroObject.attackSpeed = 5;
		heroObject.armorPen = 0;
		heroObject.dexterity = 5;
		heroObject.basicAttackCooldown = 5;

		// Init enemy stats...
		enemyObject.health = 1000;
		enemyObject.strength = 100;
		enemyObject.armor = 100;
		enemyObject.accuracy = 30;
		enemyObject.evasion = 40;
		enemyObject.critChance = 10;
        enemyObject.critMultiplier = 300;
		enemyObject.blockChance = 20;
        enemyObject.blockMultiplier = 75;
        enemyObject.finesse = 20;
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

        if (missCheck <= ((defender.evasion) * (1-(attacker.accuracy/100)))) {
            print("Miss!");
            return;
            
        }   //end if

        float damage = attacker.strength;

        int block = 0;
        int crit = 0;

        var blockCheck = Random.Range(1, 100);
        var critCheck = Random.Range(1, 100);


        if (blockCheck <= ((defender.blockChance) * (1-(attacker.finesse/100)))) {
            damage *= (1-(defender.blockMultiplier/100));
            attacker.armorPen /= 2;
            block = 1;

        }   //end if

        /*block chance and initial block effects. */


        if (block == 0 && critCheck <= attacker.critChance) {
            damage *= (attacker.critMultiplier/100);
            attacker.armorPen *= 2;
            crit = 1;

        }   //end if
            
        /*crit chance and initial crit effects.  */

        defender.armor *= (1 - (attacker.armorPen/100));
        damage *= (100 / (100 + defender.armor));

		defender.health -= damage;

        if (block == 1)
            print("Blocked! Damage dealt: " + damage);

        else if (crit == 1)
            print("Critical strike! Damage dealt: " + damage);

        else print("Damage dealt: " + damage);

		print("Defender health after damage: " + defender.health);
		print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	}	// end Attack()

}  // end class
