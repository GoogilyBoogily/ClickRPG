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
		heroObject.health = 100;
		heroObject.strength = 5;
		heroObject.armor = 5;
		heroObject.accuracy = 5;
		heroObject.evasion = 5;
		heroObject.crit = 5;
		heroObject.block = 5;
		heroObject.attackSpeed = 5;
		heroObject.armorPen = 5;
		heroObject.dexterity = 5;
		heroObject.basicAttackCooldown = 5;

		// Init enemy stats...
		enemyObject.health = 100;
		enemyObject.strength = 2;
		enemyObject.armor = 2;
		enemyObject.accuracy = 2;
		enemyObject.evasion = 2;
		enemyObject.crit = 2;
		enemyObject.block = 2;
		enemyObject.attackSpeed = 2;
		enemyObject.armorPen = 2;
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
		print("Defender health before damage: " + defender.health);

		defender.health -= attacker.strength;



		print("Defender health after damage: " + defender.health);

		print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	}	// end Attack()

}  // end class
