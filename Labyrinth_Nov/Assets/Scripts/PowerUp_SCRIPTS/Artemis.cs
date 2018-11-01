using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artemis : PowerUpsDisplay {

    [SerializeField] private GameObject hermes;
    [SerializeField] private PlayerPowers power;
    //[SerializeField] private GameObject _____;
    //[SerializeField] private GameObject _____;

    public override void ApplyPowerUp(){
        power.SetPowers("artemis"); 
    }

    public override void DestroyOtherPowerUps(){
        Destroy(hermes);
    }

}
