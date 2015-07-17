using UnityEngine;
using System.Collections;
using Abilities;

public class ChargePunch : Ability {

    public ChargePunch() {

        name = "Charge Punch";
        description = "A big ol' punch. Hurts like the dickens.";
        abilityType = AbilityTypes.Burst;
        targetScope = TargetScopes.SingleEnemy;

        damagesTarget = true;

        chargeDuration = 2.0f;
        abilityDuration = 1.0f;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;
        procLimit = 1;
        
        procSpacing = 2.0f;
        procDamage = 100.0f;
        procHeal = 0.0f;

        resource = "";
        cost = 0.0f;
        cooldown = 3.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
