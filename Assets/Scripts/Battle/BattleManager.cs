﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

using BattleObjects;
using Heroes;
using Enemies;
using Abilities;


public class BattleManager : MonoBehaviour {

    public TestHero heroObjectOne = new TestHero();
    public TestHero2 heroObjectTwo = new TestHero2();

    public MonsterMallow enemyObjectOne = new MonsterMallow();
    public Kangaremu enemyObjectTwo = new Kangaremu();

    Queue battleQueue = new Queue();
    Queue multipleTargetQueue = new Queue();

    float battleTimer = 0.0f;

    bool doesBennetSuck = true;

    public Hero selectedHero;
    public BattleObject actingBattleObject;

    BattleObject allHeroes = new BattleObject();
    BattleObject allEnemies = new BattleObject();

    List<BattleObject> battleObjectList = new List<BattleObject>();
    List<Hero> heroList = new List<Hero>();
    List<Enemy> enemyList = new List<Enemy>();

    public bool enemyOneClicked = false;
    public bool enemyTwoClicked = false;

    public void EnemyOneClicked() {
        enemyOneClicked = true;
        Debug.Log("Way to click on that enemyOne! Nice!");
    }
    public void EnemyTwoClicked() {
        enemyTwoClicked = true;
        Debug.Log("Way to click on that enemyTwo! Splendid!");
    }

    public Text HeroOneHealthDisplay;
    public Text HeroTwoHealthDisplay;

    public Text EnemyOneHealthDisplay;
    public Text EnemyTwoHealthDisplay;
   
      
    public BattleManager() {

        battleObjectList.Add(heroObjectOne);
        battleObjectList.Add(heroObjectTwo);
        battleObjectList.Add(enemyObjectOne);
        battleObjectList.Add(enemyObjectTwo);

        heroList.Add(heroObjectOne);
        heroList.Add(heroObjectTwo);

        enemyList.Add(enemyObjectOne);
        enemyList.Add(enemyObjectTwo);

    }


    void OnGUI() {

        //This is seriously the old, shitty way of doing this. I'm doing it to make testing a little easier, 
        //but we REALLY need to use the new UI system. It takes some getting used to, but I figured out
        //some of the very basics (those buttons that don't do much, that is).

       
        GUI.Label(new Rect(10, 10, 120, 20), selectedHero.name.ToString());
        GUI.Label(new Rect(10, 40, 120, 20), selectedHero.currentBattleState.ToString());
        GUI.Label(new Rect(10, 70, 120, 20), selectedHero.queuedAbility.name.ToString());
        GUI.Label(new Rect(10, 100, 120, 20), selectedHero.currentAbility.name.ToString());

        GUI.Label(new Rect(170, 70, 120, 20), selectedHero.currentAbility.targetChosen.ToString());
        GUI.Label(new Rect(170, 100, 120, 20), selectedHero.currentAbility.infChargeTimer.ToString());
  
    }


    // Use this for initialization
    void Start() {

        // Init bools for button presses (NOT HERE, currently on update - should figure out how to make update take from this.)

        // Init battlestates and abilities for objects

        heroObjectOne.currentBattleState = BattleObject.BattleStates.Wait;
        heroObjectOne.currentAbility = heroObjectOne.abilities[0];
        heroObjectOne.queuedAbility = heroObjectOne.abilities[0];
        heroObjectOne.currentHealth = heroObjectOne.maxHealth;

        heroObjectTwo.currentBattleState = BattleObject.BattleStates.Wait;
        heroObjectTwo.currentAbility = heroObjectTwo.abilities[0];
        heroObjectTwo.queuedAbility = heroObjectTwo.abilities[0];
        heroObjectTwo.currentHealth = heroObjectTwo.maxHealth;

        Debug.Log(heroObjectOne.name + "'s Health: " + heroObjectOne.currentHealth);
        Debug.Log(heroObjectTwo.name + "'s Health: " + heroObjectTwo.currentHealth);

        enemyObjectOne.currentHealth = enemyObjectOne.maxHealth;
        enemyObjectTwo.currentHealth = enemyObjectTwo.maxHealth;

        Debug.Log(enemyObjectOne.name + "'s Health: " + enemyObjectOne.currentHealth);
        Debug.Log(enemyObjectTwo.name + "'s Health: " + enemyObjectTwo.currentHealth);

        if (doesBennetSuck) {
            selectedHero = heroObjectOne;
        }

        //tying stuff to health bars...it worked, but then each one ran BattleManager. 
        //I guess I could make a script that just handles things being passed to the GUI...bleh. I mean I totally can,
        //But that strikes me as a dumb way to do it.

        


    }   // end Start()


    // Update is called once per frame, running through every battleObject's battleState.
    void Update() {

        //button presses here, is dumb way of doing it, but it works for now

        bool heroOneSelectKeyed = Input.GetButtonDown("Hero One Select");
        bool heroTwoSelectKeyed = Input.GetButtonDown("Hero Two Select");

        bool abilityOneKeyed = Input.GetButtonDown("Ability One");
        bool abilityTwoKeyed = Input.GetButtonDown("Ability Two");
        bool abilityThreeKeyed = Input.GetButtonDown("Ability Three");

        bool heroObjectOneTargeted = Input.GetButtonDown("Hero One Target");
        bool heroObjectTwoTargeted = Input.GetButtonDown("Hero Two Target");

        bool enemyObjectOneTargeted = Input.GetButtonDown("Enemy One Target");
        bool enemyObjectTwoTargeted = Input.GetButtonDown("Enemy Two Target");

        bool abilityCanceled = Input.GetButtonDown("Cancel Ability");


        //Displaying health numbers! Fun.

        HeroOneHealthDisplay.text = heroObjectOne.name.ToString() + "'s health: " + heroObjectOne.currentHealth.ToString();
        HeroTwoHealthDisplay.text = heroObjectTwo.name.ToString() + "'s health: " + heroObjectTwo.currentHealth.ToString();

        EnemyOneHealthDisplay.text = enemyObjectOne.name.ToString() + "'s health: " + enemyObjectOne.currentHealth.ToString();
        EnemyTwoHealthDisplay.text = enemyObjectTwo.name.ToString() + "'s health: " + enemyObjectTwo.currentHealth.ToString();


        //Controls for hero selection

        if (selectedHero != heroObjectOne) {

            if (heroOneSelectKeyed) {
                selectedHero = heroObjectOne;
                Debug.Log(selectedHero.name + " selected!");
            }
        }

        if (selectedHero != heroObjectTwo) {

            if (heroTwoSelectKeyed) {
                selectedHero = heroObjectTwo;
                Debug.Log(selectedHero.name + " selected!");
            }
        }


        //Increment battleTimer 
 
        battleTimer += Time.deltaTime;


        //Enqueue all of the BattleObjects for going through the same switch. 
            //This will eventually have to count enemy objects and enqueue only as many as there are,
            //as well as check to make sure a hero's battlestate isn't "dead." You know, once there IS a "dead."

        battleQueue.Enqueue(heroObjectOne);
        battleQueue.Enqueue(heroObjectTwo);
        //eventually enqueue rest of heroes (this will have to draw from a list of the 1-4 heroes you have)
        
        battleQueue.Enqueue(enemyObjectOne);
        battleQueue.Enqueue(enemyObjectTwo);

        //battleQueue checks for anything in the queue. At the beginning of every frame, everything is enqueued, 
            //and each time it runs through the switch down below, it dequeues something. 
            //When it's through every BattleObject, battleQueue.Count will return 0, and we're on to the next frame.

        while (battleQueue.Count > 0) {

            actingBattleObject = (BattleObject)battleQueue.Peek();

            //Switch checks for what BattleState the object it is, and figures out what that
            //object needs to do in this frame.

            switch (actingBattleObject.currentBattleState) {

                case (BattleObject.BattleStates.Wait): //waitj

                    //Commands can be issued in Wait. Eventually, heroes will have a default
                    //ability to default back to (infinite barrage usually), and at that point
                    //"wait" will only be used at battle start, after the hero is revived, etc.

                    if (actingBattleObject == selectedHero) {

                        if (abilityOneKeyed) {
                            if ((actingBattleObject.abilities[1].isLocked != true)
                                && (battleTimer > actingBattleObject.abilities[1].cooldownEndTimer)) {

                                actingBattleObject.queuedAbility = selectedHero.abilities[1]; 
                                actingBattleObject.commandIssued = true;
                            }
                        } //end abilityOneKeyed

                        if (abilityTwoKeyed) {
                            if ((actingBattleObject.abilities[2].isLocked != true)
                                && (battleTimer > actingBattleObject.abilities[2].cooldownEndTimer)) {

                                actingBattleObject.queuedAbility = selectedHero.abilities[2]; 
                                actingBattleObject.commandIssued = true;
                            }
                        } //end abilityTwoKeyed

                        if (abilityThreeKeyed) {
                            if ((actingBattleObject.abilities[3].isLocked != true)
                                && (battleTimer > actingBattleObject.abilities[3].cooldownEndTimer)) {

                                actingBattleObject.queuedAbility = selectedHero.abilities[3]; 
                                actingBattleObject.commandIssued = true;
                            }
                        } //end abilityThreeKeyed

                    } //end key input

                    if (actingBattleObject.commandIssued == true) {

                        if (actingBattleObject.queuedAbility.abilityType == Ability.AbilityTypes.InfCharge) {

                            actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                            actingBattleObject.currentBattleState = BattleObject.BattleStates.InfCharge;
                            actingBattleObject.currentAbility.isLocked = true;
                        }

                        else {
                            actingBattleObject.currentBattleState = BattleObject.BattleStates.Target;
                        }

                    } //end if command issued

                    actingBattleObject.commandIssued = false;

                    break; //end Wait case



                case (BattleObject.BattleStates.Target): //jtar

                    if (actingBattleObject == selectedHero) {

                        if (abilityCanceled) {
                            Debug.Log(actingBattleObject.queuedAbility.name + " canceled!");
                            actingBattleObject.queuedAbility = actingBattleObject.abilities[0];
                            actingBattleObject.currentBattleState = BattleObject.BattleStates.Wait;

                        } //end if ability canceleds

                        if (actingBattleObject.queuedAbility.targetChosen != true) {

                            if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.SingleEnemy) {

                                if (enemyObjectOneTargeted) {
                                    actingBattleObject.queuedAbility.currentTarget = enemyObjectOne;
                                    actingBattleObject.queuedAbility.targetChosen = true;
                                }

                                if (enemyObjectTwoTargeted) {
                                    actingBattleObject.queuedAbility.currentTarget = enemyObjectTwo;
                                    actingBattleObject.queuedAbility.targetChosen = true;
                                }

                            } //end if single enemy


                            else if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.SingleHero) {

                                if (heroObjectOneTargeted) {
                                    actingBattleObject.queuedAbility.currentTarget = heroObjectOne;
                                    actingBattleObject.queuedAbility.targetChosen = true;
                                }

                                if (heroObjectTwoTargeted) {
                                    actingBattleObject.queuedAbility.currentTarget = heroObjectTwo;
                                    actingBattleObject.queuedAbility.targetChosen = true;
                                }

                            } //end if single hero

                            else if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.AllEnemies) {

                                actingBattleObject.queuedAbility.currentTarget = allEnemies;
                                actingBattleObject.queuedAbility.targetChosen = true;

                            } //end if all enemies

                            else if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.AllHeroes) {

                                actingBattleObject.queuedAbility.currentTarget = allHeroes;
                                actingBattleObject.queuedAbility.targetChosen = true;

                            } //end if all heroes

                        } //end if target not chosen


                        else if (actingBattleObject.queuedAbility.targetChosen == true) {

                            actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                            actingBattleObject.queuedAbility = actingBattleObject.abilities[0];
                            actingBattleObject.currentAbility.chargeStartTimer = battleTimer;

                            if (actingBattleObject.currentAbility.hasCharge == true) {
                                actingBattleObject.currentBattleState = BattleObject.BattleStates.Charge;
                            }

                            else {

                                if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.Burst) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.Burst;
                                }

                                else if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.Barrage) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.Barrage;
                                }

                                else if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfBarrage) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.InfBarrage;
                                }

                            } //end else (has no charge)

                            actingBattleObject.currentAbility.targetChosen = false;

                        } //end if targetChosen = true

                    } //end if actingBattleObject = selectedHero

                    break; //end Target case


                case (BattleObject.BattleStates.Charge):

                    //Charge as in actually charging for a Burst or Barrage.

                    //check for timer & ability type Burst, dumping appropriately
                    if ((battleTimer > (actingBattleObject.currentAbility.chargeStartTimer + actingBattleObject.currentAbility.chargeDuration)) 
                        && (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.Burst)) {

                        actingBattleObject.currentBattleState = BattleObject.BattleStates.Burst;
                    }

                    //check for timer & ability type Barrage, dumping appropriately
                    else if ((battleTimer > (actingBattleObject.currentAbility.chargeStartTimer + actingBattleObject.currentAbility.chargeDuration)) 
                        && (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.Barrage)) {

                        actingBattleObject.currentAbility.abilityStartTimer = battleTimer;
                        actingBattleObject.currentBattleState = BattleObject.BattleStates.Barrage;
                    }

                    //check for timer & ability type Barrage, dumping appropriately
                    else if ((battleTimer > (actingBattleObject.currentAbility.chargeStartTimer + actingBattleObject.currentAbility.chargeDuration)) 
                        && (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfBarrage)) {

                        actingBattleObject.currentAbility.abilityStartTimer = battleTimer;
                        actingBattleObject.currentBattleState = BattleObject.BattleStates.InfBarrage;
                    }

                    break; //end Charge case


                case (BattleObject.BattleStates.Burst): //jburst

                    if (actingBattleObject.currentAbility.damagesTarget) {

                        if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                            actingBattleObject.currentAbility.infProcDamage = (actingBattleObject.currentAbility.procDamage * actingBattleObject.currentAbility.infChargeTimer);
                        }


                        if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.SingleEnemy) {

                            if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                actingBattleObject.currentAbility.currentTarget.currentHealth -= actingBattleObject.currentAbility.infProcDamage;
                            }

                            else {
                                actingBattleObject.currentAbility.currentTarget.currentHealth -= actingBattleObject.currentAbility.procDamage;
                            }

                            Debug.Log(actingBattleObject + " uses " + actingBattleObject.currentAbility.name + " on " + actingBattleObject.currentAbility.currentTarget + "!");
                            Debug.Log(actingBattleObject.currentAbility.currentTarget.name + "'s health: " + actingBattleObject.currentAbility.currentTarget.currentHealth);

                        } //end if single enemy


                        else if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.AllEnemies) {

                            enemyList.ForEach(multipleTargetQueue.Enqueue);

                            while (multipleTargetQueue.Count > 0) {

                                actingBattleObject.currentAbility.currentTarget = (BattleObject)multipleTargetQueue.Peek();

                                if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                    actingBattleObject.currentAbility.currentTarget.currentHealth -= actingBattleObject.currentAbility.infProcDamage;
                                }

                                else {
                                    actingBattleObject.currentAbility.currentTarget.currentHealth -= actingBattleObject.currentAbility.procDamage;
                                }

                                Debug.Log(actingBattleObject.currentAbility.currentTarget.name + "'s health: " + actingBattleObject.currentAbility.currentTarget.currentHealth);
                                multipleTargetQueue.Dequeue();
                            }

                        } //end if all enemies

                    } //end if damagesTarget
                    
                    else if (actingBattleObject.currentAbility.healsTarget) {

                        if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                            actingBattleObject.currentAbility.infProcHeal = (actingBattleObject.currentAbility.procHeal * actingBattleObject.currentAbility.infChargeTimer);
                        }

                        if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.SingleHero) {

                            if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfCharge)
                                actingBattleObject.currentAbility.currentTarget.currentHealth += actingBattleObject.currentAbility.infProcHeal;

                            else {
                                actingBattleObject.currentAbility.currentTarget.currentHealth += actingBattleObject.currentAbility.procHeal;
                            }

                            if (actingBattleObject.currentAbility.currentTarget.currentHealth >= actingBattleObject.currentAbility.currentTarget.maxHealth) {
                                actingBattleObject.currentAbility.currentTarget.currentHealth = actingBattleObject.currentAbility.currentTarget.maxHealth;
                            }

                            Debug.Log(actingBattleObject + " uses " + actingBattleObject.currentAbility.name + " on " + actingBattleObject.currentAbility.currentTarget + "!");
                            Debug.Log(actingBattleObject.currentAbility.currentTarget.currentHealth);

                        } //end if heals single hero


                        else if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.AllHeroes) {

                            Debug.Log(actingBattleObject.name + " uses " + actingBattleObject.currentAbility.name + " on the party!");

                            heroList.ForEach(multipleTargetQueue.Enqueue);

                            while (multipleTargetQueue.Count > 0) {

                                actingBattleObject.currentAbility.currentTarget = (BattleObject)multipleTargetQueue.Peek();

                                if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                    actingBattleObject.currentAbility.currentTarget.currentHealth += actingBattleObject.currentAbility.infProcHeal;
                                }

                                else {
                                    actingBattleObject.currentAbility.currentTarget.currentHealth += actingBattleObject.currentAbility.procHeal;
                                }

                                if (actingBattleObject.currentAbility.currentTarget.currentHealth >= actingBattleObject.currentAbility.currentTarget.maxHealth) {
                                    actingBattleObject.currentAbility.currentTarget.currentHealth = actingBattleObject.currentAbility.currentTarget.maxHealth;
                                }

                                Debug.Log(actingBattleObject.currentAbility.currentTarget.name + "'s health: " + actingBattleObject.currentAbility.currentTarget.currentHealth);
                                multipleTargetQueue.Dequeue();

                            } //end queue while

                        } //end if heals all heroes

                    } //end if healsTarget

                    //HERE is where we have gotten through what the ability does, and we reset everything.

                    //reset timers/bools

                    actingBattleObject.currentAbility.chargeStartTimer = 0;
                    actingBattleObject.currentAbility.abilityStartTimer = 0;
                    actingBattleObject.currentAbility.infChargeTimer = 0;

                    actingBattleObject.commandIssued = false;

                    actingBattleObject.currentAbility.isLocked = false;
                    actingBattleObject.currentAbility.targetChosen = false;
                    
                    actingBattleObject.queuedAbility.isLocked = false;
                    actingBattleObject.queuedAbility.targetChosen = false;
                   
                    //set cooldown

                    actingBattleObject.currentAbility.cooldownEndTimer = battleTimer + actingBattleObject.currentAbility.cooldown;

                    //reset everything else

                    actingBattleObject.currentAbility = actingBattleObject.abilities[0];
                    actingBattleObject.queuedAbility = actingBattleObject.abilities[0];
                    actingBattleObject.currentBattleState = BattleObject.BattleStates.Wait;
                        
        
                    break; //end Burst case


                case (BattleObject.BattleStates.Barrage): //barragej

                    //check for barrage limits being reached

                    if ((battleTimer < (actingBattleObject.currentAbility.abilityStartTimer + actingBattleObject.currentAbility.abilityDuration)) &&
                        (actingBattleObject.currentAbility.procCounter < actingBattleObject.currentAbility.procLimit)) {

                        //check if it's time to proc, proc if so!

                        if (battleTimer >= (actingBattleObject.currentAbility.lastProcTimer + actingBattleObject.currentAbility.procSpacing)) {

                            if (actingBattleObject.currentAbility.damagesTarget) {

                                if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.SingleEnemy) {

                                    actingBattleObject.currentAbility.currentTarget.currentHealth -= actingBattleObject.currentAbility.procDamage;

                                    Debug.Log(actingBattleObject.currentAbility.currentTarget + "'s health: " + actingBattleObject.currentAbility.currentTarget.currentHealth);

                                    actingBattleObject.currentAbility.procCounter++;
                                    actingBattleObject.currentAbility.lastProcTimer = battleTimer;

                                } //end if single enemy damage

                                if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.AllEnemies) {

                                    enemyList.ForEach(multipleTargetQueue.Enqueue);

                                    while (multipleTargetQueue.Count > 0) {

                                        actingBattleObject.currentAbility.currentTarget = (BattleObject)multipleTargetQueue.Peek();
                                        actingBattleObject.currentAbility.currentTarget.currentHealth -= actingBattleObject.currentAbility.procDamage;
                                        Debug.Log(actingBattleObject.currentAbility.currentTarget.name + "'s health: " + actingBattleObject.currentAbility.currentTarget.currentHealth);
                                        multipleTargetQueue.Dequeue();

                                    } //end queue while

                                    actingBattleObject.currentAbility.procCounter++;
                                    actingBattleObject.currentAbility.lastProcTimer = battleTimer;

                                } //end if all enemies damage
                            
                            } //end if damages target

                            else if (actingBattleObject.currentAbility.healsTarget) {

                                if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.SingleHero) { 

                                    if (actingBattleObject.currentAbility.currentTarget.currentHealth + actingBattleObject.currentAbility.procHeal <= actingBattleObject.currentAbility.currentTarget.maxHealth) {
                                        actingBattleObject.currentAbility.currentTarget.currentHealth += actingBattleObject.currentAbility.procHeal;
                                    }

                                    else {
                                        actingBattleObject.currentAbility.currentTarget.currentHealth = actingBattleObject.maxHealth;
                                    }

                                    Debug.Log(actingBattleObject.currentAbility.currentTarget.currentHealth);

                                } //end if single hero heal

                                else if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.AllHeroes) {

                                    heroList.ForEach(multipleTargetQueue.Enqueue);

                                    while (multipleTargetQueue.Count > 0) {

                                        actingBattleObject.currentAbility.currentTarget = (BattleObject)multipleTargetQueue.Peek();

                                        if (actingBattleObject.currentAbility.currentTarget.currentHealth + actingBattleObject.currentAbility.procHeal <= actingBattleObject.currentAbility.currentTarget.maxHealth) {
                                            actingBattleObject.currentAbility.currentTarget.currentHealth += actingBattleObject.currentAbility.procHeal;
                                        }

                                        else {
                                            actingBattleObject.currentAbility.currentTarget.currentHealth = actingBattleObject.maxHealth;
                                        }

                                        Debug.Log(actingBattleObject.currentAbility.currentTarget.name + "'s health: " + actingBattleObject.currentAbility.currentTarget.currentHealth);
                                        multipleTargetQueue.Dequeue();

                                    } // end queue while

                                } //end if all heroes heal

                            } //end if heals target

                            actingBattleObject.currentAbility.procCounter++;
                            actingBattleObject.currentAbility.lastProcTimer = battleTimer;
                            

                        } //end if (proc checks/stuff)

                    } //end if(barrage limit checks)

                    //if barrage limits are reached, reset timers and type/state
                    else {

                        //reset timers/counters

                        actingBattleObject.currentAbility.chargeStartTimer = 0;
                        actingBattleObject.currentAbility.abilityStartTimer = 0;
                        actingBattleObject.currentAbility.infChargeTimer = 0;

                        actingBattleObject.currentAbility.lastProcTimer = 0.0f;
                        actingBattleObject.currentAbility.procCounter = 0;

                        //set cooldown

                        actingBattleObject.currentAbility.cooldownEndTimer = battleTimer + actingBattleObject.currentAbility.cooldown;

                        //reset everything else

                        actingBattleObject.currentAbility.isLocked = false;
                        actingBattleObject.currentAbility.targetChosen = false;

                        actingBattleObject.currentAbility = actingBattleObject.abilities[0];
                        actingBattleObject.currentBattleState = BattleObject.BattleStates.Wait;

                    }

                    break; //end barrage case


                case (BattleObject.BattleStates.InfBarrage): //infbarragej

                    //Barrage section: obviously the most important one. 
                    //Until a new ability AND a target for that ability are chosen, 
                    //the barrage will continue.

                    //check if it's time to proc, and proc if so!

                    if (battleTimer >= (actingBattleObject.currentAbility.lastProcTimer + actingBattleObject.currentAbility.procSpacing)) {

                        if (actingBattleObject.currentAbility.damagesTarget) {

                            if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.SingleEnemy) {

                                actingBattleObject.currentAbility.currentTarget.currentHealth -= actingBattleObject.currentAbility.procDamage;

                                Debug.Log(actingBattleObject.currentAbility.currentTarget + "'s health: " + actingBattleObject.currentAbility.currentTarget.currentHealth);

                                } //end if single enemy damage

                            if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.AllEnemies) {

                                enemyList.ForEach(multipleTargetQueue.Enqueue);

                                while (multipleTargetQueue.Count > 0) {

                                    actingBattleObject.currentAbility.currentTarget = (BattleObject)multipleTargetQueue.Peek();
                                    actingBattleObject.currentAbility.currentTarget.currentHealth -= actingBattleObject.currentAbility.procDamage;
                                    Debug.Log(actingBattleObject.currentAbility.currentTarget.name + "'s health: " + actingBattleObject.currentAbility.currentTarget.currentHealth);
                                    multipleTargetQueue.Dequeue();

                                } //end queue while

                            } //end if all enemies damage

                        } //end if damages target

                        else if (actingBattleObject.currentAbility.healsTarget) {

                            if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.SingleHero) {

                                if (actingBattleObject.currentAbility.currentTarget.currentHealth + actingBattleObject.currentAbility.procHeal <= actingBattleObject.currentAbility.currentTarget.maxHealth) {
                                    actingBattleObject.currentAbility.currentTarget.currentHealth += actingBattleObject.currentAbility.procHeal;
                                }

                                else {
                                    actingBattleObject.currentAbility.currentTarget.currentHealth = actingBattleObject.maxHealth;
                                }

                                Debug.Log(actingBattleObject.currentAbility.currentTarget.currentHealth);

                            } //end if single hero heal

                            else if (actingBattleObject.currentAbility.targetScope == Ability.TargetScopes.AllHeroes) {

                                heroList.ForEach(multipleTargetQueue.Enqueue);

                                while (multipleTargetQueue.Count > 0) {

                                    actingBattleObject.currentAbility.currentTarget = (BattleObject)multipleTargetQueue.Peek();

                                    if (actingBattleObject.currentAbility.currentTarget.currentHealth + actingBattleObject.currentAbility.procHeal <= actingBattleObject.currentAbility.currentTarget.maxHealth) {
                                        actingBattleObject.currentAbility.currentTarget.currentHealth += actingBattleObject.currentAbility.procHeal;
                                    }

                                    else {
                                        actingBattleObject.currentAbility.currentTarget.currentHealth = actingBattleObject.maxHealth;
                                    }

                                    Debug.Log(actingBattleObject.currentAbility.currentTarget.name + "'s health: " + actingBattleObject.currentAbility.currentTarget.currentHealth);
                                    multipleTargetQueue.Dequeue();

                                } // end queue while

                            } //end if all heroes heal

                        } //end if heals target

                        actingBattleObject.currentAbility.procCounter++;
                        actingBattleObject.currentAbility.lastProcTimer = battleTimer;

                    } //end if for proc check

                    //End barrage section of InfBarrage
                

                    //Begin command section (essentially BattleStates.Wait)

                        if (abilityOneKeyed && actingBattleObject == selectedHero) {

                            if (battleTimer > actingBattleObject.abilities[1].cooldownEndTimer) {

                                actingBattleObject.queuedAbility = actingBattleObject.abilities[1];
                                actingBattleObject.commandIssued = true;

                                if (actingBattleObject.queuedAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                    actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.InfCharge;
                                    actingBattleObject.commandIssued = false;
                                }

                                else if (actingBattleObject.queuedAbility.targetScope == (Ability.TargetScopes.SingleEnemy | Ability.TargetScopes.SingleHero)) {
                                    Debug.Log("Select a Target! ('o' and 'p' for enemies, 'n' and 'm' for heroes! Otherwise, hit 'x' to cancel.)");
                                }
                            } //end if off cooldown

                            else {
                                Debug.Log(actingBattleObject.name + "'s '" + actingBattleObject.abilities[1] + "' is on cooldown for " + (actingBattleObject.abilities[1].cooldownEndTimer - battleTimer) + " seconds!");
                            }

                        } //end ability one keyed

                        else if (abilityTwoKeyed && actingBattleObject == selectedHero) {

                            if (battleTimer > actingBattleObject.abilities[2].cooldownEndTimer) {

                                actingBattleObject.queuedAbility = actingBattleObject.abilities[2];
                                actingBattleObject.commandIssued = true;

                                if (actingBattleObject.queuedAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                    actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.InfCharge;
                                    actingBattleObject.commandIssued = false;
                                }

                                else if (actingBattleObject.queuedAbility.targetScope == (Ability.TargetScopes.SingleEnemy | Ability.TargetScopes.SingleHero)) {
                                    Debug.Log("Select a Target! ('o' and 'p' for enemies, 'n' and 'm' for heroes! Otherwise, hit 'x' to cancel.)");
                                }
                            } //end if off cooldown

                            else {
                                Debug.Log(actingBattleObject.name + "'s '" + actingBattleObject.abilities[2] + "' is on cooldown for " + (actingBattleObject.abilities[2].cooldownEndTimer - battleTimer) + " seconds!");
                            }

                        } //end ability two keyed

                        else if (abilityThreeKeyed && actingBattleObject == selectedHero) {

                            if (battleTimer > actingBattleObject.abilities[3].cooldownEndTimer) {

                                actingBattleObject.queuedAbility = actingBattleObject.abilities[3];
                                actingBattleObject.commandIssued = true;

                                if (actingBattleObject.queuedAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                    actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.InfCharge;
                                    actingBattleObject.commandIssued = false;
                                }

                                else if (actingBattleObject.queuedAbility.targetScope == (Ability.TargetScopes.SingleEnemy | Ability.TargetScopes.SingleHero)) {
                                    Debug.Log("Select a Target! ('o' and 'p' for enemies, 'n' and 'm' for heroes! Otherwise, hit 'x' to cancel.)");
                                }
                            }

                            else {
                                Debug.Log(actingBattleObject.name + "'s '" + actingBattleObject.abilities[3] + "' is on cooldown for " + (actingBattleObject.abilities[3].cooldownEndTimer - battleTimer) + " seconds!");
                            }

                        } //end ability three keyed


                    //End command section of InfBarrage
                    
                    //Begin targeting section of InfBarrage

                    if (actingBattleObject.commandIssued == true) {

                        if (abilityCanceled) {
                            Debug.Log(actingBattleObject.queuedAbility.name + " canceled!");
                            actingBattleObject.queuedAbility = actingBattleObject.abilities[0];
                        }

                        if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.SingleEnemy) {

                            if (actingBattleObject == selectedHero && enemyObjectOneTargeted) {

                                actingBattleObject.currentAbility.cooldownEndTimer = battleTimer + actingBattleObject.currentAbility.cooldown;
                                actingBattleObject.currentAbility.targetChosen = false;

                                actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                                actingBattleObject.queuedAbility = actingBattleObject.abilities[0];

                                actingBattleObject.currentAbility.currentTarget = enemyObjectOne;
                                actingBattleObject.currentAbility.targetChosen = true;
                                actingBattleObject.currentAbility.chargeStartTimer = battleTimer;

                                Debug.Log(actingBattleObject.name + " begins charging " + actingBattleObject.currentAbility.name + " on " + actingBattleObject.currentAbility.currentTarget.name + "!");
                            }

                            else if (actingBattleObject == selectedHero && enemyObjectTwoTargeted) {

                                actingBattleObject.currentAbility.cooldownEndTimer = battleTimer + actingBattleObject.currentAbility.cooldown;
                                actingBattleObject.currentAbility.targetChosen = false;

                                actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                                actingBattleObject.queuedAbility = actingBattleObject.abilities[0];

                                actingBattleObject.currentAbility.currentTarget = enemyObjectTwo;
                                actingBattleObject.currentAbility.targetChosen = true;
                                actingBattleObject.currentAbility.chargeStartTimer = battleTimer;

                                Debug.Log(actingBattleObject.name + " begins charging " + actingBattleObject.currentAbility.name + " on " + actingBattleObject.currentAbility.currentTarget.name + "!");
                            }

                        } //end if single enemy

                        if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.SingleHero) {

                            if (actingBattleObject == selectedHero && heroObjectOneTargeted) {

                                actingBattleObject.currentAbility.cooldownEndTimer = battleTimer + actingBattleObject.currentAbility.cooldown;
                                actingBattleObject.currentAbility.targetChosen = false;

                                actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                                actingBattleObject.queuedAbility = actingBattleObject.abilities[0];

                                actingBattleObject.currentAbility.currentTarget = heroObjectOne;
                                actingBattleObject.currentAbility.targetChosen = true;
                                actingBattleObject.currentAbility.chargeStartTimer = battleTimer;

                                Debug.Log(actingBattleObject.name + " begins charging " + actingBattleObject.currentAbility.name + " on " + actingBattleObject.currentAbility.currentTarget.name + "!");
                            }

                            else if (actingBattleObject == selectedHero && heroObjectTwoTargeted) {

                                actingBattleObject.currentAbility.cooldownEndTimer = battleTimer + actingBattleObject.currentAbility.cooldown;
                                actingBattleObject.currentAbility.targetChosen = false;

                                actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                                actingBattleObject.queuedAbility = actingBattleObject.abilities[0];

                                actingBattleObject.currentAbility.currentTarget = heroObjectTwo;
                                actingBattleObject.currentAbility.targetChosen = true;
                                actingBattleObject.currentAbility.chargeStartTimer = battleTimer;

                                Debug.Log(actingBattleObject.name + " begins charging " + actingBattleObject.currentAbility.name + " on " + actingBattleObject.currentAbility.currentTarget.name + "!");
                            }

                        } //end if single hero


                        if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.AllHeroes) {

                            actingBattleObject.currentAbility.cooldownEndTimer = battleTimer + actingBattleObject.currentAbility.cooldown;
                            actingBattleObject.currentAbility.targetChosen = false;

                            actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                            actingBattleObject.queuedAbility = actingBattleObject.abilities[0];

                            actingBattleObject.currentAbility.currentTarget = allHeroes;
                            actingBattleObject.currentAbility.targetChosen = true;
                            actingBattleObject.currentAbility.chargeStartTimer = battleTimer;

                            Debug.Log(actingBattleObject.name + " begins charging " + actingBattleObject.currentAbility.name + " on the party!");

                        } //end if all heroes


                        if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.AllEnemies) {

                            actingBattleObject.currentAbility.cooldownEndTimer = battleTimer + actingBattleObject.currentAbility.cooldown;
                            actingBattleObject.currentAbility.targetChosen = false;

                            actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                            actingBattleObject.queuedAbility = actingBattleObject.abilities[0];

                            actingBattleObject.currentAbility.currentTarget = allEnemies;
                            actingBattleObject.currentAbility.targetChosen = true;
                            actingBattleObject.currentAbility.chargeStartTimer = battleTimer;

                            Debug.Log(actingBattleObject.name + " begins charging " + actingBattleObject.currentAbility.name + " on all enemies!");

                        } //end if all Enemies
   

                        if (actingBattleObject.currentAbility.targetChosen == true) {

                            if (actingBattleObject.currentAbility.hasCharge == true) {
                                actingBattleObject.currentBattleState = BattleObject.BattleStates.Charge;
                            }

                            else {

                                if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.Burst) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.Burst;
                                }

                                else if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.Barrage) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.Barrage;
                                }

                                else if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfBarrage) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.InfBarrage;
                                }

                                else if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.InfCharge;
                                    actingBattleObject.currentAbility.isLocked = true;
                                }  

                            } //end else (has no charge)

                            actingBattleObject.currentAbility.targetChosen = false;

                        } //end if targetChosen = true

                    } //end if command issued 

                    break; //end InfBarrage case



                case (BattleObject.BattleStates.InfCharge) : //infchargej

                    actingBattleObject.currentAbility.infChargeTimer += Time.deltaTime;

                    if (actingBattleObject == selectedHero) {

                        if (abilityOneKeyed) {
                            if ((actingBattleObject.abilities[1].isLocked != true)
                                && (battleTimer > actingBattleObject.abilities[1].cooldownEndTimer)) {

                                actingBattleObject.currentAbility.isLocked = false;

                                actingBattleObject.queuedAbility = selectedHero.abilities[1];
                                actingBattleObject.commandIssued = true;
                                
                                if (actingBattleObject.queuedAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                    actingBattleObject.queuedAbility.isLocked = true;
                                }
                            }
                        } //end abilityOneKeyed

                        if (abilityTwoKeyed) {
                            if ((actingBattleObject.abilities[2].isLocked != true)
                                && (battleTimer > actingBattleObject.abilities[2].cooldownEndTimer)) {

                                actingBattleObject.currentAbility.isLocked = false;

                                actingBattleObject.queuedAbility = selectedHero.abilities[2];
                                actingBattleObject.commandIssued = true;

                                if (actingBattleObject.queuedAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                    actingBattleObject.queuedAbility.isLocked = true;
                                }
                            }
                        } //end abilityTwoKeyed

                        if (abilityThreeKeyed) {
                            if ((actingBattleObject.abilities[3].isLocked != true)
                                && (battleTimer > actingBattleObject.abilities[3].cooldownEndTimer)) {

                                actingBattleObject.currentAbility.isLocked = false;

                                actingBattleObject.queuedAbility = selectedHero.abilities[3];
                                actingBattleObject.commandIssued = true;

                                if (actingBattleObject.queuedAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                    actingBattleObject.queuedAbility.isLocked = true;
                                }
                            }
                        } //end abilityThreeKeyed

                        if (actingBattleObject.commandIssued == true) {

                            if (actingBattleObject.queuedAbility.abilityType == Ability.AbilityTypes.InfCharge) {

                                actingBattleObject.currentAbility.isLocked = false;

                                if (actingBattleObject.currentAbility.retainsInfCharge != true) {
                                    actingBattleObject.currentAbility.infChargeTimer = 0;
                                }

                                actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                                actingBattleObject.currentAbility.isLocked = true;
                                actingBattleObject.commandIssued = false;

                            } //end if another InfCharge
                                
                        } //end if command issued


                        if (abilityCanceled) {

                            actingBattleObject.currentAbility.isLocked = false;

                            if (actingBattleObject.currentAbility.retainsInfCharge != true) {
                                actingBattleObject.currentAbility.infChargeTimer = 0;
                            }

                            Debug.Log(actingBattleObject.queuedAbility.name + " canceled!");
                            actingBattleObject.queuedAbility = actingBattleObject.abilities[0];
                            actingBattleObject.currentAbility = actingBattleObject.abilities[0];
                            actingBattleObject.currentBattleState = BattleObject.BattleStates.Wait;

                        } //end if ability canceleds

                        if (actingBattleObject.queuedAbility.targetChosen != true) {

                            if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.SingleEnemy) {

                                if (enemyObjectOneTargeted) {
                                    actingBattleObject.queuedAbility.currentTarget = enemyObjectOne;
                                    actingBattleObject.queuedAbility.targetChosen = true;
                                }

                                if (enemyObjectTwoTargeted) {
                                    actingBattleObject.queuedAbility.currentTarget = enemyObjectTwo;
                                    actingBattleObject.queuedAbility.targetChosen = true;
                                }

                            } //end if single enemy


                            else if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.SingleHero) {

                                if (heroObjectOneTargeted) {
                                    actingBattleObject.queuedAbility.currentTarget = heroObjectOne;
                                    actingBattleObject.queuedAbility.targetChosen = true;
                                }

                                if (heroObjectTwoTargeted) {
                                    actingBattleObject.queuedAbility.currentTarget = heroObjectTwo;
                                    actingBattleObject.queuedAbility.targetChosen = true;
                                }

                            } //end if single hero

                            else if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.AllEnemies) {

                                actingBattleObject.queuedAbility.currentTarget = allEnemies;
                                actingBattleObject.queuedAbility.targetChosen = true;

                            } //end if all enemies

                            else if (actingBattleObject.queuedAbility.targetScope == Ability.TargetScopes.AllHeroes) {

                                actingBattleObject.queuedAbility.currentTarget = allHeroes;
                                actingBattleObject.queuedAbility.targetChosen = true;

                            } //end if all heroes

                        } //end if target not chosen


                        else if (actingBattleObject.queuedAbility.targetChosen == true) {

                            actingBattleObject.currentAbility.isLocked = false;
                            

                            if ((actingBattleObject.currentAbility != actingBattleObject.queuedAbility) && (actingBattleObject.currentAbility.retainsInfCharge != true)) {
                                actingBattleObject.currentAbility.infChargeTimer = 0;
                            }

                            actingBattleObject.currentAbility = (Ability)actingBattleObject.queuedAbility;
                            actingBattleObject.queuedAbility = actingBattleObject.abilities[0];
                            actingBattleObject.currentAbility.chargeStartTimer = battleTimer;

                            if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfCharge) {
                                actingBattleObject.currentBattleState = BattleObject.BattleStates.Burst;

                            }

                            else if (actingBattleObject.currentAbility.hasCharge == true) {
                                actingBattleObject.currentBattleState = BattleObject.BattleStates.Charge;
                            }

                            else {

                                if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.Burst) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.Burst;
                                }

                                else if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.Barrage) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.Barrage;
                                }

                                else if (actingBattleObject.currentAbility.abilityType == Ability.AbilityTypes.InfBarrage) {
                                    actingBattleObject.currentBattleState = BattleObject.BattleStates.InfBarrage;
                                }

                            } //end else (has no charge)

                        } //end if targetChosen = true

                    } //end if selectedHero = actingBattleObject


                    break; //end InfCharge case


            } //end BattleStates switch

            battleQueue.Dequeue();

        } //end battleQueue "while"

    } //end Update

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