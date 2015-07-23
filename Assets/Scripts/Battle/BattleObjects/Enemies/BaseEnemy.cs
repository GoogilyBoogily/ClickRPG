using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using BattleObjects;

namespace Enemies {
    public class Enemy : BattleObject  {

        public Enemy() {

            targetType = TargetTypes.EnemyTarget;

            //Notice that there's not much here yet - that's because it all inherits from BattleObject,
            //and heroes and enemies share a lot of those qualities. 
            //This script is just for things that make a hero a hero.

        }
    }
}