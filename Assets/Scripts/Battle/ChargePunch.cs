using UnityEngine;
using System.Collections;
using Abilities;

public class ChargePunch : Ability {

    public ChargePunch() {

        name = "Charge Punch";
        description = "A big ol' punch.";
        type = AbilityTypes.Burst;
        target = "Single";

        chargeDuration = 2.0f;
        abilityDuration = 1.0f;

        procSpacing = 2.0f;
        procDamage = 100.0f;
        procLimit = 1;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;

        resource = "";
        cost = 0.0f;
        cooldown = 3.0f;

    } //end constructor()



}
