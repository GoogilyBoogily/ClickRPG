using UnityEngine;
using System.Collections;
using Abilities;

public class FireBall : Ability {

    public FireBall() {

        name = "Fire Ball";
        description = "OMG DAT CHICK JUST MADE FIRE WID HER HANDS.";
        type = AbilityTypes.Burst;
        effectOne = ProcEffects.Damage;
        target = "Single";

        chargeDuration = 4.0f;
        abilityDuration = 0.0f;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;
        procLimit = 1000;

        procSpacing = 0.0f;
        procDamage = 250.0f;

        resource = "";
        cost = 0.0f;
        cooldown = 5.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()



}
