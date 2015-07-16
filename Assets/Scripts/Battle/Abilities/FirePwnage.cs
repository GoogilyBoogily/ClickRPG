using UnityEngine;
using System.Collections;
using Abilities;

public class FirePwnage : Ability {

    public FirePwnage() {

        name = "Fire Pwnage";
        description = "OH GOD THIS IS ENOUGH FIRE TO KILL AT LEAST ALL OF THE SPIDERS EVER.";
        type = AbilityTypes.Barrage;
        effectOne = ProcEffects.Damage;
        target = "Single";

        chargeDuration = 4.0f;
        abilityDuration = 3.0f;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;
        procLimit = 1000;

        procSpacing = 0.20f;
        procDamage = 12.0f;

        resource = "";
        cost = 0.0f;
        cooldown = 3.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
