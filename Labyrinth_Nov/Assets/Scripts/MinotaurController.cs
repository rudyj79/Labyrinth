﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MinotaurController : MonoBehaviour{

    public NavMeshAgent agent; // the minotaur
    public GameObject player; // reference for the player object
    private bool startMoving = false;
    private bool bang;

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    public void FollowPlayer()
    {
        startMoving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("GameOverScreen", LoadSceneMode.Single);
        }
        if (other.tag == "spikes")
        {
            StartCoroutine(StuckInTrap());
        }
    }
    IEnumerator StuckInTrap()
    {
        agent.speed = 0;
        yield return new WaitForSeconds(1f);
        agent.speed = 8;
    }
}