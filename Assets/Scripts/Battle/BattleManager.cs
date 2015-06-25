using UnityEngine;
using System.Collections;
using Heroes;
using Enemies;
using Abilities;




public class BattleManager : MonoBehaviour {
	// Enum for which phase in the battle we're in
	//		This is used so we can pause the timer when casting and attacking are occuring
	enum ControlPhases {
		Initializing,
		Waiting,
		Charging,
		Attacking,
        Unresponsive
	}	// end enum

	// Init a variable to hold our current battle phase
	BattlePhases currBattlePhase = BattlePhases.Initializing;

	// Init a battle timer to keep track of time during the battle
	float battleTimer = 0.0f;

	// Init the player and enemy objects
	TestHero heroObject = new TestHero();
	TestEnemy enemyObject = new TestEnemy();

	// Creates and initializes a new Queue.
	Queue battleQueue = new Queue();


	// Use this for initialization
	void Start() {
		// Schedule everyone's first attack
		// (We should be scheduling the object with the lowest proc spacing first)
		ScheduleAttack(heroObject);
		ScheduleAttack(enemyObject);

		// Set the battle timer to "waiting" so that it begins incrementing
		currBattlePhase = BattlePhases.Waiting;

	}   // end Start()


	// Update is called once per frame
	void Update() {
		
			// Add the time onto the battle timer
			battleTimer += Time.deltaTime;

			// If it's the battle object at the beginning of the queue's time to attack, attack!
			//	And then schedule its next attack
			if( ((BattleObject)battleQueue.Peek()).attackTime <= battleTimer ) {
				BattleObject attackingObject = (BattleObject)battleQueue.Dequeue();
                Attack(attackingObject);

				ScheduleAttack(attackingObject);
			}	//end if
		}	// end if
		
	}   // end Update()



        foreach (Ability ability in objectToScheduleAttack.abilities) {
            
        }

		// Take the object that we have to schedule an attack for, and grab its cooldown
		float objectCooldown = objectToScheduleAttack.abilities.procSpacing;

		// Add the cooldown to the current time to get its next attack time
		float nextAttackTime = battleTimer + procSpacing;

		// Set the objects next attack time
		objectToScheduleAttack.attackTime = nextAttackTime;

		// Enqueue it into the queue
		battleQueue.Enqueue(objectToScheduleAttack);
	}	// end ScheduleAttack


	// Takes in the attacker and defender and computes damage done
    void Attack(BattleObject attacker) {
		BattleObject defender;

		if(attacker.type == "hero") {
			defender = enemyObject;
        } else {
			defender = heroObject;
		}	// end else/if

		print("Attacker: " + attacker.type);

		// Do battle algorithm stuff here

        var missCheck = Random.Range(1, 100);

        if (missCheck <= ((defender.evasion) * (1-(attacker.accuracy/100)))) {
            print("Miss!");
            print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
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

        if (block == 1) {
            print("Blocked! Damage dealt: " + damage);

        } else if (crit == 1) {
            print("Critical strike! Damage dealt: " + damage);

        } else { 
            print("Damage dealt: " + damage); 
        } // end if/else block

        print("Defender health after damage: " + defender.health);
		print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
	}	// end Attack()
 // end class
} 