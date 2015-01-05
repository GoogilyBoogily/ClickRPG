using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;

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

		public float critChance {
			get; set;
		}

        public float critMultiplier {
            get; set;
        }

		public float blockChance {
			get; set;
		}

        public float blockMultiplier {
            get; set;
        }

        public float finesse {
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

        public float tenacity {
            get; set;
        }

        public float resolve {
            get; set;
        }

		public float basicAttackCooldown {
			get; set;
		}

		public string target {
			get; set;
		}

		public float attackTime {
			get; set;
		}


		public List<Ability> abilities = new List<Ability>();


		// Instance Constructor
		public BattleObject() {
			type = "";
			health = 0;
			strength = 0;
			armor = 0;
			accuracy = 0;
			evasion = 0;
			critChance = 0;
            critMultiplier = 0;
			blockChance = 0;
            blockMultiplier = 0;
			attackSpeed = 0;
			armorPen = 0;
			dexterity = 0;
            tenacity = 0;
            resolve = 0;
			basicAttackCooldown = 0;
			target = "";
			attackTime = -1.0f;
        }   // end constructor()

	}	// end class


	public class BasicHero : BattleObject {
		// Instance Constructor
		public BasicHero() {
			type = "hero";
			target = "enemy";

			// Init hero stats...
			health = 1000;
			strength = 100;
			armor = 100;
			accuracy = 50;
			evasion = 50;
			critChance = 20;
			critMultiplier = 200;
			blockChance = 20;
			blockMultiplier = 50;
			finesse = 30;
			attackSpeed = 5;
			armorPen = 0;
			dexterity = 5;
			tenacity = 0;
			resolve = 0;
			basicAttackCooldown = 3;
		}	// end constructor()

	}  // end class


	public class BasicEnemy : BattleObject {
		// Instance Constructor
		public BasicEnemy() {
			type = "enemy";
			target = "hero";

			// Init enemy stats...
			health = 1000;
			strength = 100;
			armor = 100;
			accuracy = 30;
			evasion = 40;
			critChance = 10;
			critMultiplier = 300;
			blockChance = 20;
			blockMultiplier = 75;
			finesse = 20;
			attackSpeed = 2;
			armorPen = 0;
			dexterity = 2;
			tenacity = 0;
			resolve = 0;
			basicAttackCooldown = 6;
		}	// end constructor()

	}  // end class


}  // end namespace
