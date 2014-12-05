using System.Collections;

namespace Abilities {
    public class Ability {
        // Properties
        public string type {
            get; set;
        }

        public string primaryDamageType {
            get; set;
        }

        public string element {
            get; set;
        }

        public float duration {
            get; set;
        }

        public float strengthModifer {
            get; set;
        }

        public float wisdomModifier {
            get; set;
        }

        public float accuracyModifier {
            get; set;
        }

        public float critChance {
            get; set;
        }

        public float critMultiplier {
            get; set;
        }

        public float finesseModifier {
            get; set;
        }

        public float attackSpeed {
            get; set;
        }

        public float armorPenModifier {
            get; set;
        }

        public float dexterityModifier {
            get; set;
        }

        public float procCooldown {
            get; set;
        }

        public string target {
            get; set;
        }

        public float abilityStartTime {
            get; set;
        }


        // Instance Constructor
        public Ability() {
            type = "";
            primaryDamageType = "";
            element = "";
            duration = 0;
            strengthModifer = 0;
            wisdomModifier = 0;
            accuracyModifier = 0;
            armorPenModifier = 0;
            critChance = 0;
            critMultiplier = 0;
            finesseModifier = 0;
            dexterityModifier = 0;
            procCooldown = 0;
            target = "";
            abilityStartTime = -1.0f;
        }   // end constructor()

    }   //end class
}   // end namespace