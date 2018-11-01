using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public CharacterController charController;


    // Use this for initialization
    void Start(){
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update(){
        MovePlayer();
        //GetPlayersAbilites();
    }

    public virtual void MovePlayer(){}
    //public virtual void GetPlayersAbilites() {}

}
