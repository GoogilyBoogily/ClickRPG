using UnityEngine;
using System.Collections;
using Abilities;

public class PunchBarrage : Ability {

	public PunchBarrage() {

        name = "Punch Barrage";
        description = "A barrage of punches.";
        type = AbilityTypes.Barrage;
        target = "Single";

        chargeDuration = 2.0f;
        abilityDuration = 2.0f;

        procSpacing = 0.33f;
        procDamage = 15.0f;
        procLimit = 1000;

        chargeStartTimer = 0.0f;
        abilityStartTimer = 0.0f;
        lastProcTimer = 0.0f;
        procCounter = 0;

        resource = "";
        cost = 0.0f;
        cooldown = 3.0f;

    } //end constructor()

    
	
}
