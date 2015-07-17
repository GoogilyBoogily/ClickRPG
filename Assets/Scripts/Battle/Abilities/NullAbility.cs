using UnityEngine;
using System.Collections;
using Abilities;

public class NullAbility : Ability {

    public NullAbility () {

        name = "Null Ability";
        description = "For when you just gotta do nothin'.";
        abilityType = AbilityTypes.Null;
        targetScope = TargetScopes.Null;

        chargeDuration = 0.0f;
        abilityDuration = 0.0f;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;
        procLimit = 0;

        procSpacing = 0.0f;
        procDamage = 0.0f;
        procHeal = 0.0f;

        resource = "";
        cost = 0.0f;
        cooldown = 0.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
