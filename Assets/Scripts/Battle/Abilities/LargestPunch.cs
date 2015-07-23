using UnityEngine;
using System.Collections;
using Abilities;

public class LargestPunch : Ability {

    public LargestPunch() {

        name = "Largest Punch";
        description = "Makes Donkey Kong's neutral B attack look like tiny little hungry girl hitting brick wall. Retains charge if canceled.";
        abilityType = AbilityTypes.InfCharge;
        targetScope = TargetScopes.SingleEnemy;

        damagesTarget = true;
        retainsInfCharge = true;

        chargeDuration = 0.0f;
        abilityDuration = 0.0f;

        chargeStartTimer = 0.0f;
        infChargeTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;

        procCounter = 0;
        procLimit = 1000;
        procSpacing = 0.0f;
        procDamage = 60;
        infProcDamage = 0;

        resource = "";
        cost = 0.0f;
        cooldown = 1.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
