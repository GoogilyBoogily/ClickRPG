using System.Collections;
using BattleObjects;

namespace Abilities {
    public class Ability {
        
        public enum AbilityTypes {
            Null,
            Burst,
            Barrage,
            InfCharge,
            InfBarrage,
            Toggle
        }

        public enum TargetScopes {
            Null,
            Untargeted,
            SingleHero,
            SingleEnemy,
            SingleHeroOrEnemy,
            AllHeroes,
            AllEnemies,
            AllHeroesAndEnemies
        }


        // Properties
		public string name {
			get; set;
		}

		public string description {
			get; set;
		}

        public AbilityTypes abilityType {
            get; set;
        }

        public TargetScopes targetScope {
            get; set;
        }

        public BattleObject currentTarget {
            get; set;
        }

        //Ability bools - the ones not handled by the AbilityTypes I guess

        public bool targetChosen {
            get; set;
        }

        public bool hasCharge {
            get; set;
        }

        public bool retainsInfCharge {
            get; set;
        }


        //Proc Effects
        public bool damagesTarget {
            get; set;
        }

        public bool healsTarget {
            get; set;
        }

        public bool healsUser {
            get; set;
        }

        public bool addsStatus {
            get; set;
        }


        //Durations
        public float chargeDuration {
            get; set;
        }

		public float abilityDuration {
			get; set;
		}

  
        //Timers

        public float chargeStartTimer {
            get; set;
        }

        public float abilityStartTimer {
            get; set;
        }

        public float infChargeTimer {
            get; set;
        }

        public float lastProcTimer {
            get; set;
        }
       

        //Proc handlings

        public int procCounter {
            get; set;
        }
        public int procLimit {
            get; set;
        }

        public float procSpacing {
            get; set;
        }

        public float procDamage {
            get; set;
        }

        public float infProcDamage {
            get; set;
        }

        public float procHeal {
            get; set;
        }

        public float infProcHeal {
            get; set;
        }

        //Resource management

		public string resource {
			get; set;
		}

		public float cost {
			get; set;
		}

        public float cooldown {
            get; set;
        }

        public float cooldownEndTimer {
            get; set;
        }


        // Instance Constructor
        public Ability() {

			name = "";
			description = "";
            abilityType = AbilityTypes.Null;
            targetScope = TargetScopes.Null;
            currentTarget = null;
            targetChosen = false;

            hasCharge = true;
            retainsInfCharge = false;

            damagesTarget = false;
            healsTarget = false;
            healsUser = false;
            addsStatus = false;

            chargeDuration = 1.0f;
			abilityDuration = 1.0f;

            chargeStartTimer = 0.0f;
            infChargeTimer = 0.0f;
            abilityStartTimer = 0.0f;
            lastProcTimer = 0.0f;

            procCounter = 0;
            procLimit = 1;
			procSpacing = 1.0f;

            procDamage = 0.0f;
            infProcDamage = 0.0f;
            procHeal = 0.0f;
            infProcHeal = 0.0f;

			resource = "";
			cost = 10.0f;
            cooldown = 1.0f;
            cooldownEndTimer = 0.0f;

        } // end constructor

    } // end class

} // end namespace