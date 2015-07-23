using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using BattleObjects;

namespace Effects {
    public class BaseEffect {

        // Use this for initialization
        public enum EffectTypes {
            Null,
            InnateEffect,
            StatusEffect,
            ToggleEffect,
            LumpEffect,
            StackingEffect,
            LinkingEffect
        } // end EffectTypes enum

        public string name {
            get; set;
        }

        public string description {
            get; set;
        }

        public EffectTypes effectType {
            get; set;
        }

        public BattleObject effectedObject {
            get; set;
        }


        // Nuts & bolts

        public float baseDuration {
            get; set;
        }

        public float resolveScale {
            get; set;
        }

        public float effectStartTimer {
            get; set;
        }

        public BaseEffect() {

            name = "";
            description = "";
            effectType = EffectTypes.Null;

            baseDuration = 0.0f;
            resolveScale = 1.0f;
            effectStartTimer = 0.0f;



        } //end constructor

    } //end class

} //end namespace