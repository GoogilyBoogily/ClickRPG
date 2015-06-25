using UnityEngine;
using System.Collections;
using Abilities;

public class TestAbility1 : Ability {

	public TestAbility1() {
        name = "Pokey-poke";
        description = "Pokes. Hard.";
        type = "";
        target = "";
        abilityStartTime = 5.0f;
        chargeTime = 2.0f;
        duration = 10.0f;
        resource = "";
        cost = 0.0f;
        procSpacing = 1.0f;
        procDamage = 10.0f;
    } //end constructor()

    
	
}
