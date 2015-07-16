using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using BattleObjects;

namespace Heroes {
    public class Hero : BattleObject {

        public string name;
        public string description;


        //Hero Stats

        public float strength;
        public float dexterity;
        public float physicalPenetration;
        public float physicalAccuracy;
        public float physicalFinesse;
        public float physicalCritChance;
        public float physicalCritMultiplier;

        public float armor;
        public float physicalEvasion;
        public float physicalBlockChance;
        public float physicalBlockMultiplier;

        public float wisdom;
        public float celerity;
        public float magicalPenetration;
        public float magicalAccuracy;
        public float magicalFinesse;
        public float magicalCritChance;
        public float magicalCritMultiplier;

        public float spirit;
        public float magicalEvasion;
        public float magicalBlockChance;
        public float magicalBlockMultiplier;

        public float health;
        public float healthRegen;
        public float mana;
        public float manaRegen;
        public float tenacity;
        public float resolve;

       
        //Ability list, and an object keeping track of the current ability

        public List<Ability> abilities;

        

        //Targeting? I'll just leave this here for now.

        public string target;
    }
}