using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoorScript : MonoBehaviour {
    
    private bool openSesame;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if(openSesame == true)
        {
            OpenDoor();
        }
    }

    public void OpenDoor(){
        openSesame = true;
        const float MAX_OPEN = .18f;
        float openSpeed = 3.5f;
        if (transform.position.z < MAX_OPEN)
        {
            transform.Translate(0, 0, openSpeed * Time.deltaTime);
        }
    }
}
