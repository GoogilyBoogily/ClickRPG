using UnityEngine;
using System.Collections;
using Abilities;

public class TestAbility2 : Ability {

    public TestAbility2() {
        name = "Smacky-Smack";
        description = "Smacks. Way hard.";
        type = "";
        target = "";
        abilityStartTime = -1.0f;
        chargeTime = 4.0f;
        duration = 10.0f;
        resource = "";
        cost = 0.0f;
        procSpacing = 2.0f;
        procDamage = 20.0f;
    } //end constructor()



}
