using UnityEngine;
using System.Collections;
using Heroes;
using Enemies;
using Abilities;


public class BattleManager : MonoBehaviour {


    float battleTimer = 0.0f;

    // Init player & enemy objects

    TestHero heroObject = new TestHero();
    MonsterMallow enemyObject = new MonsterMallow();

    // Creates and initializes a new Queue.
    Queue battleQueue = new Queue();


    // Use this for initialization
    void Start() {
        heroObject.currentBattleState = Hero.BattleStates.Wait;
        heroObject.currentAbility = heroObject.abilities[0];
        Debug.Log("Enemy Health: " + enemyObject.health);

    }   // end Start()


    // Update is called once per frame, running through every battleObject's battleState.
    void Update() {

        //Increment battleTimer (makes sure this happens, regardless of state
 
        //Eventually, Update will run through a switch for EVERYTHING in the battle
            //and the timer should happen before that, just once.

        battleTimer += Time.deltaTime;

        //Switch checks for what BattleState the object it is, and figures out what that
            //object needs to do in this frame.

        switch (heroObject.currentBattleState) {

            case (Hero.BattleStates.Wait):

                //Commands can be issued in Wait. Eventually, heroes will have a default
                    //ability to default back to (infinite barrage usually), and at that
                    //"wait" will only be used at battle start, after the hero is revived, etc.

                bool abilityOneKeyed = Input.GetButtonDown("Ability One");
                bool abilityTwoKeyed = Input.GetButtonDown("Ability Two");


                if (abilityOneKeyed) {

                    if (heroObject.abilityOneCooldownTimer < battleTimer) {

                        heroObject.currentAbility = heroObject.abilities[1];
                        Debug.Log("Charging " + heroObject.currentAbility.name + "!");
                        heroObject.currentAbility.chargeStartTimer = battleTimer;
                        heroObject.currentBattleState = Hero.BattleStates.Charge;

                    }

                   else {
                        Debug.Log(heroObject.abilities[1] + " is on cooldown for " + (heroObject.abilityOneCooldownTimer - battleTimer) + " seconds!");
                    }

                }

                else if (abilityTwoKeyed) {

                    if (heroObject.abilityTwoCooldownTimer < battleTimer) {

                        heroObject.currentAbility = heroObject.abilities[2];
                        Debug.Log("Charging " + heroObject.currentAbility.name + "!");
                        heroObject.currentAbility.chargeStartTimer = battleTimer;
                        heroObject.currentBattleState = Hero.BattleStates.Charge;

                    }

                    else {
                        Debug.Log(heroObject.abilities[2] + " is on cooldown for " + (heroObject.abilityTwoCooldownTimer - battleTimer) + " seconds!");
                    }

                }

                break;

            case (Hero.BattleStates.Charge):

                //Charge as in actually charging for a Burst or Barrage.

                //check for timer & ability type Burst, dumping appropriately

                if ((battleTimer > (heroObject.currentAbility.chargeStartTimer + heroObject.currentAbility.chargeDuration)) && (heroObject.currentAbility.type == Ability.AbilityTypes.Burst)) {

                    Debug.Log(heroObject.currentAbility.name + "!");
                    heroObject.currentBattleState = Hero.BattleStates.Burst;
                    }

                //check for timer & ability type Barrage, dumping appropriately

                else if ((battleTimer > (heroObject.currentAbility.chargeStartTimer + heroObject.currentAbility.chargeDuration)) && (heroObject.currentAbility.type == Ability.AbilityTypes.Barrage)) {


                    Debug.Log(heroObject.currentAbility.name + "!");
                    heroObject.currentAbility.abilityStartTimer = battleTimer;
                    heroObject.currentBattleState = Hero.BattleStates.Barrage;
                }

                break;

            case (Hero.BattleStates.Burst):

                //decrement health (proc)

                enemyObject.health -= heroObject.currentAbility.procDamage;
                Debug.Log(enemyObject.health);


                //Set cooldown timer

                if (heroObject.currentAbility == heroObject.abilities[1]) {
                        heroObject.abilityOneCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[2]) {
                        heroObject.abilityTwoCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[3]) {
                        heroObject.abilityThreeCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[4]) {
                        heroObject.abilityFourCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[5]) {
                        heroObject.abilityFiveCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[6]) {
                        heroObject.abilitySixCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                // reset currentAbility and currentBattleState

                    heroObject.currentAbility.chargeStartTimer = 0.0f;
                    heroObject.currentAbility = heroObject.abilities[0];
                    heroObject.currentBattleState = Hero.BattleStates.Wait;

                break;

            case (Hero.BattleStates.Barrage):

                //check for barrage limits being reached

                if (battleTimer < (heroObject.currentAbility.abilityStartTimer + heroObject.currentAbility.abilityDuration)) { 


                    //check if it's time to proc, and proc if so

                    if (battleTimer >= (heroObject.currentAbility.lastProcTimer + heroObject.currentAbility.procSpacing)) {

                        enemyObject.health -= heroObject.currentAbility.procDamage;
                        heroObject.currentAbility.procCounter++;
                        heroObject.currentAbility.lastProcTimer = battleTimer;
                        Debug.Log(enemyObject.health);
                    
                    } //end if

                } //end if(barrage limit checks)

                //if barrage limits are reached, reset timers and type/state

                else {

                    //reset timers/counters

                    heroObject.currentAbility.chargeStartTimer = 0;
                    heroObject.currentAbility.abilityStartTimer = 0;

                    heroObject.currentAbility.lastProcTimer = 0.0f;
                    heroObject.currentAbility.procCounter = 0;


                    //set cooldown

                    if (heroObject.currentAbility == heroObject.abilities[1]) {
                        heroObject.abilityOneCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[2]) {
                        heroObject.abilityTwoCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[3]) {
                        heroObject.abilityThreeCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[4]) {
                        heroObject.abilityFourCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[5]) {
                        heroObject.abilityFiveCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    else if (heroObject.currentAbility == heroObject.abilities[6]) {
                        heroObject.abilitySixCooldownTimer = battleTimer + heroObject.currentAbility.cooldown;
                    }

                    //reset currentAbility and currentBattleState
                   
                    heroObject.currentAbility = heroObject.abilities[0];
                    heroObject.currentBattleState = Hero.BattleStates.Wait;

                }

                break;

        }



    }
}

     //END UPDATE - there is another one below, this is your LINE OF YOU UNDERSTAND, MOSTLY

        

			// If it's the battle object at the beginning of the queue's time to attack, attack!
			//	And then schedule its next attack
        
            /*Taking out the queue for now (Monster Mallow doesn't fight back)


			if( ((BattleObject)battleQueue.Peek()).attackTime <= battleTimer ) {
				BattleObject attackingObject = (BattleObject)battleQueue.Dequeue();
                Attack(attackingObject);

				ScheduleAttack(attackingObject);
			}	//end if
		}	// end if
		
	}   // end Update()
             * SEAN NOTICE THIS - scheduling attacks happens in update, and then other stuff happens!



        foreach (Ability ability in objectToScheduleAttack.abilities) {
            
        }

		// Take the object that we have to schedule an attack for, and grab its cooldown (proc spacing??)
		float objectCooldown = objectToScheduleAttack.abilities.procSpacing;

		// Add the cooldown to the current time to get its next attack time
		float nextAttackTime = battleTimer + procSpacing;

		// Set the objects next attack time
		objectToScheduleAttack.attackTime = nextAttackTime;

		// Enqueue it into the queue
		battleQueue.Enqueue(objectToScheduleAttack);
	}	// end ScheduleAttack

             */



    /* too fancy for now

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

        //block chance and initial block effects


        if (block == 0 && critCheck <= attacker.critChance) {
            damage *= (attacker.critMultiplier/100);
            attacker.armorPen *= 2;
            crit = 1;

        }   //end if
            
        // crit chance and initial crit effects.

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

    */