using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using BattleObjects;

namespace Heroes {
    public class Hero : BattleObject {

        public Hero() {

            targetType = TargetTypes.HeroTarget;

            //Notice that there's not much here yet - that's because it all inherits from BattleObject,
            //and heroes and enemies share a lot of those qualities. 
            //This script is just for things that make a hero a hero.

        }

        public float maxMana;
        public float currentMana;
        public float manaRegen;

        public BattleObject queuedTarget;
    
    }
    
}