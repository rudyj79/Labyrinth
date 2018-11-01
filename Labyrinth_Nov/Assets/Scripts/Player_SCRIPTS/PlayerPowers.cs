using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPowers : MonoBehaviour
{

    public string powerName = "";


    void Update()
    {
        GetUniqueAbility();
    }


    public void SetPowers(string theName){
        powerName = theName;
    }

    public virtual void GetUniqueAbility() { }

}