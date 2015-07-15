using UnityEngine;
using System.Collections;
using Heroes;
using Enemies;
using Abilities;


public class BattleManager : MonoBehaviour {

    //Init a battleTimer to keep track of time (all time-based things use this)

    float battleTimer = 0.0f;
    
    //Init queues for heroes and monsters, and variables for use in the queues
    
    Queue heroQueue = new Queue();
    Hero actingHero;

    Queue enemyQueue = new Queue();
    Enemy actingEnemy;

    bool doesBennetSuck = true;

    // Init player & enemy objects

    TestHero heroObjectOne = new TestHero();
    TestHero2 heroObjectTwo = new TestHero2();

    MonsterMallow enemyObject = new MonsterMallow();

    Hero selectedHero;

    Hero consideredHero;
    

    


    // Use this for initialization
    void Start() {

        // Init bools for button presses (NOT HERE, currently on update - should figure out how to make update take from this.)

        // Init battlestates and abilities for objects

        heroObjectOne.currentBattleState = Hero.BattleStates.Wait;
        heroObjectOne.currentAbility = heroObjectOne.abilities[0];

        heroObjectTwo.currentBattleState = Hero.BattleStates.Wait;
        heroObjectTwo.currentAbility = heroObjectTwo.abilities[0];
        
        selectedHero = heroObjectOne;
        
        Debug.Log("Enemy Health: " + enemyObject.health);
        Debug.Log("Hero Health: " + heroObjectOne.health);


    }   // end Start()


    // Update is called once per frame, running through every battleObject's battleState.
    void Update() {

        //button presses here, is dumb way of doing it, but it works for now

        bool heroOneSelectKeyed = Input.GetButtonDown("Hero One");
        bool heroTwoSelectKeyed = Input.GetButtonDown("Hero Two");

        bool abilityOneKeyed = Input.GetButtonDown("Ability One");
        bool abilityTwoKeyed = Input.GetButtonDown("Ability Two");
        bool abilityThreeKeyed = Input.GetButtonDown("Ability Three");

        //Increment battleTimer (makes sure this happens, regardless of state
 
        //Eventually, Update will run through a switch for EVERYTHING in the battle
            //and the timer should happen before that, just once.

        battleTimer += Time.deltaTime;

        if (selectedHero == heroObjectOne) {

            if (heroTwoSelectKeyed) {
                selectedHero = heroObjectTwo;
                Debug.Log(selectedHero.name + " selected!");
            }
        }

        if (selectedHero == heroObjectTwo) {
            if (heroOneSelectKeyed) {
                selectedHero = heroObjectOne;
                Debug.Log(selectedHero.name + " selected!");
            }        
        }

        //Switch checks for what BattleState the object it is, and figures out what that
            //object needs to do in this frame.

        switch (heroObjectOne.currentBattleState) {

            case (Hero.BattleStates.Wait):

                //Commands can be issued in Wait. Eventually, heroes will have a default
                    //ability to default back to (infinite barrage usually), and at that
                    //"wait" will only be used at battle start, after the hero is revived, etc.

                if (selectedHero == heroObjectOne) {

                    if (abilityOneKeyed) {

                        if (battleTimer > heroObjectOne.abilities[1].cooldownEndTimer) {

                            heroObjectOne.currentAbility = heroObjectOne.abilities[1];
                            Debug.Log("Charging " + heroObjectOne.currentAbility.name + "!");

                            heroObjectOne.currentAbility.chargeStartTimer = battleTimer;
                            heroObjectOne.currentBattleState = Hero.BattleStates.Charge;

                        }

                        else {
                            Debug.Log(heroObjectOne.abilities[1] + " is on cooldown for " + (heroObjectOne.abilities[1].cooldownEndTimer - battleTimer) + " seconds!");
                        }

                    } //end ability one keyed

                    else if (abilityTwoKeyed) {

                        if (battleTimer > heroObjectOne.abilities[2].cooldownEndTimer) {

                            heroObjectOne.currentAbility = heroObjectOne.abilities[2];
                            Debug.Log("Charging " + heroObjectOne.currentAbility.name + "!");

                            heroObjectOne.currentAbility.chargeStartTimer = battleTimer;
                            heroObjectOne.currentBattleState = Hero.BattleStates.Charge;

                        }

                        else {
                            Debug.Log(heroObjectOne.abilities[2] + " is on cooldown for " + (heroObjectOne.abilities[2].cooldownEndTimer - battleTimer) + " seconds!");
                        }

                    } //end ability two keyed

                    else if (abilityThreeKeyed) {

                        if (battleTimer > heroObjectOne.abilities[3].cooldownEndTimer) {

                            heroObjectOne.currentAbility = heroObjectOne.abilities[3];
                            Debug.Log("Charging " + heroObjectOne.currentAbility.name + "!");

                            heroObjectOne.currentAbility.chargeStartTimer = battleTimer;
                            heroObjectOne.currentBattleState = Hero.BattleStates.Charge;

                        }

                        else {
                            Debug.Log(heroObjectOne.abilities[3] + " is on cooldown for " + (heroObjectOne.abilities[3].cooldownEndTimer - battleTimer) + " seconds!");
                        }

                    } //end ability three keyed

                } //end Wait case

                break;


            case (Hero.BattleStates.Charge):

                //Charge as in actually charging for a Burst or Barrage.

                //check for timer & ability type Burst, dumping appropriately

                if ((battleTimer > (heroObjectOne.currentAbility.chargeStartTimer + heroObjectOne.currentAbility.chargeDuration)) && (heroObjectOne.currentAbility.type == Ability.AbilityTypes.Burst)) {

                    Debug.Log(heroObjectOne.currentAbility.name + "!");
                    heroObjectOne.currentBattleState = Hero.BattleStates.Burst;
                    }

                //check for timer & ability type Barrage, dumping appropriately

                else if ((battleTimer > (heroObjectOne.currentAbility.chargeStartTimer + heroObjectOne.currentAbility.chargeDuration)) && (heroObjectOne.currentAbility.type == Ability.AbilityTypes.Barrage)) {


                    Debug.Log(heroObjectOne.currentAbility.name + "!");
                    heroObjectOne.currentAbility.abilityStartTimer = battleTimer;
                    heroObjectOne.currentBattleState = Hero.BattleStates.Barrage;
                }

                break;


            case (Hero.BattleStates.Burst):

                //Enqueue hero for proc

                heroQueue.Enqueue(heroObjectOne);
                
                //Set cooldown timer

                heroObjectOne.currentAbility.cooldownEndTimer = battleTimer + heroObjectOne.currentAbility.cooldown;

                //Reset chargeStartTimer and currentBattleState

                heroObjectOne.currentAbility.chargeStartTimer = 0.0f;
                heroObjectOne.currentBattleState = Hero.BattleStates.Wait;

                break;


            case (Hero.BattleStates.Barrage):

                //check for barrage limits being reached

                if (battleTimer < (heroObjectOne.currentAbility.abilityStartTimer + heroObjectOne.currentAbility.abilityDuration)) { 

                    //check if it's time to proc, and Enqueue the hero to proc if it is

                    if (battleTimer >= (heroObjectOne.currentAbility.lastProcTimer + heroObjectOne.currentAbility.procSpacing)) {

                        heroQueue.Enqueue(heroObjectOne);
                    
                    } //end if

                } //end if(barrage limit checks)

                //if barrage limits are reached, reset timers and type/state

                else {

                    //reset timers/counters

                    heroObjectOne.currentAbility.chargeStartTimer = 0;
                    heroObjectOne.currentAbility.abilityStartTimer = 0;

                    heroObjectOne.currentAbility.lastProcTimer = 0.0f;
                    heroObjectOne.currentAbility.procCounter = 0;

                    //set cooldown

                    heroObjectOne.currentAbility.cooldownEndTimer = battleTimer + heroObjectOne.currentAbility.cooldown;

                    //reset currentAbility and currentBattleState (dump the hell out of here, we done)

                    heroObjectOne.currentBattleState = Hero.BattleStates.Wait;

                } 

                break;


        } //end heroObjectOne switch


        //Leave 
        //some 
        //space 
        //so 
        //the 
        //two 
        //switches 
        //don't
        //run
        //together
        //ffs


        switch (heroObjectTwo.currentBattleState) { //Switch for heroObjectTwo battlestates (eventually these will be combined into one, I'm just wanting 2 heroes I'm SORRY)

            case (Hero.BattleStates.Wait):

                //Commands can be issued in Wait. Eventually, heroes will have a default
                //ability to default back to (infinite barrage usually), and at that
                //"wait" will only be used at battle start, after the hero is revived, etc.

                if (selectedHero == heroObjectTwo) {

                    if (abilityOneKeyed) {

                        if (battleTimer > heroObjectTwo.abilities[1].cooldownEndTimer) {

                            heroObjectTwo.currentAbility = heroObjectTwo.abilities[1];
                            Debug.Log("Charging " + heroObjectTwo.currentAbility.name + "!");

                            heroObjectTwo.currentAbility.chargeStartTimer = battleTimer;
                            heroObjectTwo.currentBattleState = Hero.BattleStates.Charge;

                        }

                        else {
                            Debug.Log(heroObjectTwo.abilities[1] + " is on cooldown for " + (heroObjectTwo.abilities[1].cooldownEndTimer - battleTimer) + " seconds!");
                        }

                    } //end ability one keyed

                    else if (abilityTwoKeyed) {

                        if (battleTimer > heroObjectTwo.abilities[2].cooldownEndTimer) {

                            heroObjectTwo.currentAbility = heroObjectTwo.abilities[2];
                            Debug.Log("Charging " + heroObjectTwo.currentAbility.name + "!");

                            heroObjectTwo.currentAbility.chargeStartTimer = battleTimer;
                            heroObjectTwo.currentBattleState = Hero.BattleStates.Charge;

                        }

                        else {
                            Debug.Log(heroObjectTwo.abilities[2] + " is on cooldown for " + (heroObjectTwo.abilities[2].cooldownEndTimer - battleTimer) + " seconds!");
                        }

                    } //end ability two keyed

                    else if (abilityThreeKeyed) {

                        if (battleTimer > heroObjectTwo.abilities[3].cooldownEndTimer) {

                            heroObjectTwo.currentAbility = heroObjectTwo.abilities[3];
                            Debug.Log("Charging " + heroObjectTwo.currentAbility.name + "!");

                            heroObjectTwo.currentAbility.chargeStartTimer = battleTimer;
                            heroObjectTwo.currentBattleState = Hero.BattleStates.Charge;


                        }

                        else {
                            Debug.Log(heroObjectTwo.abilities[3] + " is on cooldown for " + (heroObjectTwo.abilities[3].cooldownEndTimer - battleTimer) + " seconds!");
                        }

                    } //end ability three keyed

                } //end conditional hero input

                break;


            case (Hero.BattleStates.Charge):

                //Charge as in actually charging for a Burst or Barrage.

                //check for timer & ability type Burst, dumping appropriately

                if ((battleTimer > (heroObjectTwo.currentAbility.chargeStartTimer + heroObjectTwo.currentAbility.chargeDuration)) && (heroObjectTwo.currentAbility.type == Ability.AbilityTypes.Burst)) {

                    Debug.Log(heroObjectTwo.currentAbility.name + "!");
                    heroObjectTwo.currentBattleState = Hero.BattleStates.Burst;
                }

                //check for timer & ability type Barrage, dumping appropriately

                else if ((battleTimer > (heroObjectTwo.currentAbility.chargeStartTimer + heroObjectTwo.currentAbility.chargeDuration)) && (heroObjectTwo.currentAbility.type == Ability.AbilityTypes.Barrage)) {


                    Debug.Log(heroObjectTwo.currentAbility.name + "!");
                    heroObjectTwo.currentAbility.abilityStartTimer = battleTimer;
                    heroObjectTwo.currentBattleState = Hero.BattleStates.Barrage;
                }

                break;


            case (Hero.BattleStates.Burst):

                //Enqueue hero for proc

                heroQueue.Enqueue(heroObjectTwo);

                //Set cooldown timer

                heroObjectTwo.currentAbility.cooldownEndTimer = battleTimer + heroObjectTwo.currentAbility.cooldown;

                //Reset chargeStartTimer and currentBattleState

                heroObjectTwo.currentAbility.chargeStartTimer = 0.0f;
                heroObjectTwo.currentBattleState = Hero.BattleStates.Wait;

                break;


            case (Hero.BattleStates.Barrage):

                //check for barrage limits being reached

                if (battleTimer < (heroObjectTwo.currentAbility.abilityStartTimer + heroObjectTwo.currentAbility.abilityDuration)) {

                    //check if it's time to proc, and Enqueue the hero to proc if it is

                    if (battleTimer >= (heroObjectTwo.currentAbility.lastProcTimer + heroObjectTwo.currentAbility.procSpacing)) {

                        heroQueue.Enqueue(heroObjectTwo);

                    } //end if

                } //end barrage limit checks

                //if barrage limits are reached, reset timers and type/state

                else {

                    //reset timers/counters

                    heroObjectTwo.currentAbility.chargeStartTimer = 0;
                    heroObjectTwo.currentAbility.abilityStartTimer = 0;

                    heroObjectTwo.currentAbility.lastProcTimer = 0.0f;
                    heroObjectTwo.currentAbility.procCounter = 0;

                    //set cooldown

                    heroObjectTwo.currentAbility.cooldownEndTimer = battleTimer + heroObjectTwo.currentAbility.cooldown;

                    //reset currentAbility and currentBattleState (dump the hell out of here, we done)

                    heroObjectTwo.currentBattleState = Hero.BattleStates.Wait;

                }

                break;

        } //end heroObjectTwo switch



        //Queue stuff here


        while (heroQueue.Count > 0) { 

            actingHero = (Hero)heroQueue.Peek();

            if (actingHero.currentAbility.effectOne == Ability.ProcEffects.Damage) {

                enemyObject.health -= actingHero.currentAbility.procDamage;
                Debug.Log(enemyObject.health);

                actingHero.currentAbility.procCounter++;
                actingHero.currentAbility.lastProcTimer = battleTimer;
            }

            else if (actingHero.currentAbility.effectOne == Ability.ProcEffects.Heal) {
                actingHero.health += actingHero.currentAbility.procHeal;
                Debug.Log(actingHero.health);
            }

            if (actingHero.currentAbility.type == Ability.AbilityTypes.Burst) {
                actingHero.currentAbility = actingHero.abilities[0];
            }

            heroQueue.Dequeue();
        
        }

        //Pseudocode time! Lolz so fun
        
        //Count, if more than 0, go through with shtuff, otherwise dump
        //Set queueCounter int
        //Peeks at queue to get first attacking object
        //sets that object as "actingObject" or something
        //goes through attacky stuff
        //dequeues
        //peeks at queue again so long as there is another 
            //(could have a peek counter that derements)

        

    } //end update

} //end BattleManager

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