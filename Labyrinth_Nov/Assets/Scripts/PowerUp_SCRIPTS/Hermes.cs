using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermes : PowerUpsDisplay {

    [SerializeField] private GameObject artmeis;
    [SerializeField] private PlayerPowers power;
    //[SerializeField] private GameObject _____;
    //[SerializeField] private GameObject _____;

    public override void ApplyPowerUp(){
        power.SetPowers("hermes");
    }
    public override void DestroyOtherPowerUps() {
        Destroy(artmeis);
    }

}
