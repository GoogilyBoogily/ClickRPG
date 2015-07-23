using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using Heroes;
using BattleObjects;

public class ParkRanger : Hero {

    public ParkRanger() {

        name = "Park Ranger";
        description = "Ranges the park, looking for bad-doers and forestfires.";

        //Hero Stats


        physicalPenetration = 0;
        physicalAccuracy = 0;
        physicalFinesse = 0;


        armor = 0;
        physicalEvasion = 0;
        physicalBlockChance = 0;
        physicalBlockMultiplier = 0;


        magicalPenetration = 0;
        magicalAccuracy = 0;
        magicalFinesse = 0;


        spirit = 0;
        magicalEvasion = 0;
        magicalBlockChance = 0;
        magicalBlockMultiplier = 0;

        maxHealth = 2400;
        healthRegen = 5;

        maxMana = 500;
        manaRegen = 20;

        tenacity = 30;
        resolve = 0;


        //Variables to keep track of things (timers & counters)

        currentAbilityType = Ability.AbilityTypes.Null;
        currentBattleState = BattleStates.Wait;


        //Ability list

        abilities = new List<Ability>(7);

        abilities.Add(new NullAbility());
        abilities.Add(new ChargePunch());
        abilities.Add(new PunchBarrage());
        abilities.Add(new HealingPunch());


    } // end constructor
}
