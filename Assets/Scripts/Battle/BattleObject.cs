using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;

namespace BattleObjects {

    public class BattleObject {

        public string name;
        public string description;
        public string targetType;

        //Stats

        public float physicalPenetration;
        public float physicalAccuracy;
        public float physicalFinesse;

        public float magicalPenetration;
        public float magicalAccuracy;
        public float magicalFinesse;

        public float armor;
        public float physicalEvasion;
        public float physicalBlockChance;
        public float physicalBlockMultiplier;


        public float spirit;
        public float magicalEvasion;
        public float magicalBlockChance;
        public float magicalBlockMultiplier;

        public float maxHealth;
        public float currentHealth;
        public float healthRegen;

        public float tenacity;
        public float resolve;


        //List of battle states

        public enum BattleStates {
            Initializing,
            Wait,
            Charge,
            Burst,
            Barrage,
            Uncharge,
            Dead
        } // end BattleStates enum


        //List of ability types

        public enum AbilityTypes {
            Null,
            Burst,
            Barrage,
            InfCharge,
            InfBarrage,
            Toggle
        } //end AbilityTypes enum

        public enum TargetTypes {
            HeroTarget,
            HeroTargetStealthed,
            EnemyTarget
        } //end TargetTypes enum


        //Variables to keep track of current things

        public BattleStates currentBattleState;
        public AbilityTypes currentAbilityType;
        
        public Ability currentAbility;

        public List<Ability> abilities;

       
    }
}