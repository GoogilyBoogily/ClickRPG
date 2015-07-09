using UnityEngine;
using System.Collections;
using Abilities;

public class NullAbility : Ability {

    public NullAbility () {

        name = "Null Ability";
        description = "For when you just gotta do nothin'.";
        type = AbilityTypes.Null;
        target = "Single";

        chargeDuration = 0.0f;
        abilityDuration = 0.0f;

        procSpacing = 0.0f;
        procDamage = 0.0f;
        procLimit = 0;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;

        resource = "";
        cost = 0.0f;
        cooldown = 0.0f;

    } //end constructor()



}
