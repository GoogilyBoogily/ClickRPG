using UnityEngine;
using System.Collections;
using Abilities;

public class EndlessPunches : Ability {

    public EndlessPunches() {

        name = "Endless Punches";
        description = "HE JUST KEEPS PUNCHING, WILL HE EVER STOP?";

        abilityType = AbilityTypes.InfBarrage;
        targetScope = TargetScopes.SingleEnemy;

        damagesTarget = true;

        chargeDuration = 0.0f;
        abilityDuration = 0.0f;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;

        lastProcTimer = 0.0f;
        procCounter = 0;
        procLimit = 1000;

        procSpacing = 1.0f;
        procDamage = 30.0f;
        procHeal = 0.0f;

        resource = "";
        cost = 0.0f;
        cooldown = 0.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
