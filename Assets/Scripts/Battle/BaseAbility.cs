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


        //Proc handlings

		public float procSpacing {
			get; set;
		}

		public float procDamage {
			get; set;
		}

        public int procLimit {
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


        // Instance Constructor
        public Ability() {

			name = "";
			description = "";
            type = AbilityTypes.Null;
            target = "";

            chargeDuration = 1.0f;
			abilityDuration = 1.0f;

			procSpacing = 1.0f;
            lastProcTimer = 0.0f;
			procDamage = 1.0f;
            procLimit = 1;

			resource = "";
			cost = 10.0f;
            cooldown = 1.0f;

        } // end constructor()

    } // end class
} // end namespace