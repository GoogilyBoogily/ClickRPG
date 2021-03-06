﻿using UnityEngine;
using System.Collections;
using Abilities;

public class FireBall : Ability {

    public FireBall() {

        name = "Fire Ball";
        description = "OMG DAT CHICK JUST MADE FIRE WID HER HANDS. But she has to start charging again each time :/";
        abilityType = AbilityTypes.InfCharge;
        targetScope = TargetScopes.SingleEnemy;

        damagesTarget = true;

        chargeDuration = 0.0f;
        abilityDuration = 0.0f;

        chargeStartTimer = 0.0f;
        infChargeTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;

        procCounter = 0;
        procLimit = 1000;
        procSpacing = 0.0f;
        procDamage = 100;
        infProcDamage = 0;

        resource = "";
        cost = 0.0f;
        cooldown = 1.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
