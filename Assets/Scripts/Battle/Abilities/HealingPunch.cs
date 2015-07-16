using UnityEngine;
using System.Collections;
using Abilities;

public class HealingPunch : Ability {

    public HealingPunch() {

        name = "Healing Punch";
        description = "Punch yourself so hard that it feels good!";
        type = AbilityTypes.Burst;
        effectOne = ProcEffects.Heal;
        target = "Single";

        chargeDuration = 2.0f;
        abilityDuration = 1.0f;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;
        procLimit = 1;

        procSpacing = 2.0f;
        procDamage = 0.0f;
        procHeal = 200.0f;

        resource = "";
        cost = 0.0f;
        cooldown = 5.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
