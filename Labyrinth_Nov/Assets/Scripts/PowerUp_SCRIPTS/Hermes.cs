using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermes : PowerUpsDisplay {
    private float speedBoost = 50f;
    [SerializeField] private PlayerMovement moveObject;
    [SerializeField] private GameObject artmeis;
    //[SerializeField] private GameObject _____;
    //[SerializeField] private GameObject _____;


    public override void ApplyPowerUp(){
        moveObject.SetHermesSpeed(speedBoost);
    }
    public override void DestroyOtherPowerUps() {
        Destroy(artmeis);
    }

}
