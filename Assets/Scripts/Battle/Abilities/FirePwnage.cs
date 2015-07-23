using UnityEngine;
using System.Collections;
using Abilities;

public class FirePwnage : Ability {

    public FirePwnage() {

        name = "Fire Pwnage";
        description = "OH GOD THIS IS ENOUGH FIRE TO KILL AT LEAST ALL OF THE SPIDERS EVER.";
        
        abilityType = AbilityTypes.InfBarrage;
        targetScope = TargetScopes.AllEnemies;

        damagesTarget = true;

        chargeDuration = 3.0f;
        abilityDuration = 0.0f;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;
        procLimit = 1000;

        procSpacing = 1.4f;
        procDamage = 30.0f;

        resource = "";
        cost = 0.0f;
        cooldown = 0.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
