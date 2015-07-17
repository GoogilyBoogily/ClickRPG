using UnityEngine;
using System.Collections;
using Abilities;

public class HealWave : Ability {

    public HealWave() {

        name = "Heal Wave";
        description = "Waves of healing! So nice!";
        abilityType = AbilityTypes.Barrage;
        targetScope = TargetScopes.AllHeroes;

        healsTarget = true;

        chargeDuration = 3.0f;
        abilityDuration = 5.0f;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;
        procLimit = 1000;

        procSpacing = 1.0f;
        procDamage = 0.0f;
        procHeal = 70.0f;

        resource = "";
        cost = 0.0f;
        cooldown = 5.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
