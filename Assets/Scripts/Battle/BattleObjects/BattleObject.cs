using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;

namespace BattleObjects {

    public class BattleObject : Object {

        //List of battle states
        public enum BattleStates {
            Initializing,
            Wait,
            Target,
            Charge,
            Burst,
            Barrage,
            InfCharge,
            InfBarrage,
            Uncharge,
            Dead
        } // end BattleStates enum


        //List of Target types
        public enum TargetTypes {
            HeroTarget,
            HeroTargetStealthed,
            EnemyTarget
        } //end TargetTypes enum


        public string name {
			get; set;
    }

        public string description {
            get; set;
        }

        public TargetTypes targetType {
            get; set;
        }


        //Stats

        public float physicalPenetration {
            get; set;
        }

        public float physicalAccuracy {
            get; set;
        }

        public float physicalFinesse {
            get; set;
        }


        public float magicalPenetration {
            get; set;
        }

        public float magicalAccuracy {
            get; set;
        }

        public float magicalFinesse {
            get; set;
        }


        public float armor {
            get; set;
        }

        public float physicalEvasion {
            get; set;
        }

        public float physicalBlockChance {
            get; set;
        }

        public float physicalBlockMultiplier {
            get; set;
        }



        public float spirit {
            get; set;
        }

        public float magicalEvasion {
            get; set;
        }

        public float magicalBlockChance {
            get; set;
        }

        public float magicalBlockMultiplier {
            get; set;
        }


        public float maxHealth {
            get; set;
        }

        public float currentHealth {
            get; set;
        }

        public float healthRegen {
            get; set;
        }


        public float tenacity {
            get; set;
        }

        public float resolve {
            get;  set;
        }


        //Variables to keep track of current things

        public BattleStates currentBattleState {
            get; set;
        }

        public Ability.AbilityTypes currentAbilityType {
            get; set;
        }

        
        public Ability currentAbility;
        public Ability queuedAbility;

        public List<Ability> abilities;

        public bool commandIssued;
    }
}