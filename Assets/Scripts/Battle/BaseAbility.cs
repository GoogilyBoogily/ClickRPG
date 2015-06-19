using System.Collections;

namespace Abilities {
    public class Ability {
        // Properties
		public string name {
			get; set;
		}

		public string description {
			get; set;
		}

        public string type {
            get; set;
        }

        public string target {
            get; set;
        }

        public float abilityStartTime {
            get; set;
        }

		public float chargeTime {
			get; set;
		}

		public float duration {
			get; set;
		}

		public string resource {
			get; set;
		}

		public float cost {
			get; set;
		}

		public float procSpacing {
			get; set;
		}

        public float procDamage {
            get; set;
        }


        // Instance Constructor
        public Ability() {
			name = "";
			description = "";
            type = "";
            target = "";
            abilityStartTime = -1.0f;
			chargeTime = 1.0f;
			duration = 1.0f;
			resource = "";
			cost = 0.0f;
			procSpacing = 1.0f;
            procDamage = 10.0f;
        } // end constructor()

    } // end class
} // end namespace