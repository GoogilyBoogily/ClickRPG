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

		// Init hero and enemy stats...

		heroObject.health = 100;


		// void InvokeRepeating(string methodName, float time, float repeatRate);
		// Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
		InvokeRepeating("DoFight", 0, 1);
	}  // end Start()

	// Update is called once per frame
	void Update() {
		
	}  // end Update()

	// Goes through everyone in the attack queue and does their basic attacking phase
	void DoFight() {
		battleQueue.Enqueue(heroObject);
		battleQueue.Enqueue(enemyObject);


		foreach(BattleObject attacker in battleQueue) {
			Attack(attacker);
		}	// end foreach
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



		
	}	// end Attack()

}  // end class
