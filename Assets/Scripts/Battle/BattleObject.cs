using System.Collections;

namespace BattleObjects {
	public class BattleObject {
		// Properties
		public string type {
			get; set;
		}

		public float health {
			get; set;
		}

		public float strength {
			get; set;
		}

		public float armor {
			get; set;
		}

		public float accuracy {
			get; set;
		}

		public float evasion {
			get; set;
		}

		public float crit {
			get; set;
		}

		public float block {
			get; set;
		}

		public float attackSpeed {
			get; set;
		}

		public float armorPen {
			get; set;
		}

		public float dexterity {
			get; set;
		}

		public float basicAttackCooldown {
			get; set;
		}

		public string target {
			get; set;
		}


		// Instance Constructor
		public BattleObject() {
			type = "";
			health = 0;
			strength = 0;
			armor = 0;
			accuracy = 0;
			evasion = 0;
			crit = 0;
			block = 0;
			attackSpeed = 0;
			armorPen = 0;
			dexterity = 0;
			basicAttackCooldown = 0;
			target = "";
        }   // end constructor()
	}   // end class
}  // end namespace
