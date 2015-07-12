using System.Collections;

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

        public enum ProcEffects {
            Null,
            Damage,
            Heal,
            AddStatus,
            CleanseStatus
        }


        // Properties
		public string name {
			get; set;
		}

		public string description {
			get; set;
		}

        public AbilityTypes type {
            get; set;
        }

        public ProcEffects effectOne {
            get; set;
        }

        public ProcEffects effectTwo {
            get; set;
        }

        public ProcEffects effectThree {
            get; set;
        }

        public string target {
            get; set;
        }


        //Durations

        public float chargeDuration {
            get; set;
        }

		public float abilityDuration {
			get; set;
		}


        //Timers & Counters

        public float chargeStartTimer {
            get; set;
        }

        public float abilityStartTimer {
            get; set;
        }

        public float lastProcTimer {
            get; set;
        }
       
        public int procCounter {
            get; set;
        }
        public int procLimit {
            get; set;
        }


        //Proc handlings

        public float procSpacing {
            get; set;
        }

        public float procDamage {
            get; set;
        }

        public float procHeal {
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
            type = AbilityTypes.Null;
            effectOne = ProcEffects.Null;
            effectTwo = ProcEffects.Null;
            effectThree = ProcEffects.Null;
            target = "";

            chargeDuration = 1.0f;
			abilityDuration = 1.0f;

            chargeStartTimer = 0.0f;
            abilityStartTimer = 0.0f;
            lastProcTimer = 0.0f;
            procCounter = 0;
            procLimit = 1;

			procSpacing = 1.0f;
            procDamage = 0.0f;
            procHeal = 0.0f;

			resource = "";
			cost = 10.0f;
            cooldown = 1.0f;
            cooldownEndTimer = 0.0f;

        } // end constructor()

    } // end class
} // end namespace