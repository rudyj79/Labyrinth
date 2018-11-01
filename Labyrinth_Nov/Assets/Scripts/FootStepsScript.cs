using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsScript : MonoBehaviour {

    CharacterController characterController;
    public AudioSource footStep;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        footStep = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(characterController.isGrounded == true && characterController.velocity.magnitude > 2f && footStep.isPlaying == false)
        {
            footStep.volume = Random.Range(0.8f, 1f);
            footStep.pitch = Random.Range(0.8f, 1.1f);
            footStep.Play();
        }
	}

// Ryan is cooler

}
