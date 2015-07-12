using UnityEngine;
using System.Collections;
using Abilities;

public class PunchBarrage : Ability {

	public PunchBarrage() {

        name = "Punch Barrage";
        description = "Many tiny fast punches.";
        type = AbilityTypes.Barrage;
        effectOne = ProcEffects.Damage;
        target = "Single";

        chargeDuration = 2.0f;
        abilityDuration = 2.0f;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;
        procLimit = 1000;

        procSpacing = 0.33f;
        procDamage = 15.0f;

        resource = "";
        cost = 0.0f;
        cooldown = 3.0f;
        cooldownEndTimer = 0.0f;

    } //end constructor()

    
	
}
