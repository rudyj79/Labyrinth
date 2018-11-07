using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MinotaurController : MonoBehaviour{

    public NavMeshAgent agent; // the minotaur
    public GameObject player; // reference for the player object
    private bool startMoving = false;
    private bool bang;
    static Animator anim;
    private static Random ran;

    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
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
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking2", true);
            Debug.Log("player touched");
            SceneManager.LoadScene("GameOverScreen", LoadSceneMode.Single);
        } else {
            anim.SetBool("isAttacking2", false);
            anim.SetBool("isRunning", true);
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
