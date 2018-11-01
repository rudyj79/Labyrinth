using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarScript : PlayerMovement{

    public Image staminaBar;
    private float maxStamina = 100f;

    public override void ModifyStamina(){
        float theStamina = stamina / maxStamina;
        staminaBar.fillAmount = theStamina;
        if (theStamina < 1 && !Sprinting())
        {
            StaminaReturning();
        }
    }
    private void StaminaReturning(){
        stamina += .1f;
        staminaBar.fillAmount = stamina / maxStamina;
    }
}
