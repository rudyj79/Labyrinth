using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0f;
    public float hermesSpeed = 0f;
    public float stamina = 100f;
    private float baseSpeed = 8f; //9.5f
    [SerializeField] private float sprintSpeed;
    public float gravity = -9.8f;
    private float vertSpeed = 0f;
    public float jumpSpeed = 150f;
    float deltaX;
    float deltaZ;
    public CharacterController charController;

    // Use this for initialization
    void Start()
    {
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        MovePlayer();
    }

    public void MovePlayer(){
        ModifyStamina();
        if (charController.isGrounded)
        {
            if (Jumping())
            {
                vertSpeed = jumpSpeed;
            }
            else { vertSpeed = 0; }
            if (Sprinting())
            {
                speed = sprintSpeed + hermesSpeed;
                stamina -= .5f;
            }
            else { speed = baseSpeed + hermesSpeed; }
        }
        else { vertSpeed += gravity; }
        deltaX = Input.GetAxis("Horizontal") * speed;
        deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, vertSpeed, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = vertSpeed;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
    public bool Sprinting()
    {
        bool tryingToSprint = Input.GetKey("left shift") && !(stamina < 0) && (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("w") || Input.GetKey("s"));
        return tryingToSprint;
    }
    public bool Jumping()
    {
        bool tryingToJump = Input.GetButtonDown("Jump");
        return tryingToJump;
    }
    public void SetHermesSpeed(float extraSpeed)
    {
        hermesSpeed = extraSpeed;
        //Debug.Log("Current hermes speed" + this.hermesSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WinPlatform")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
            Debug.Log("Player Won");
        }
    }

    public virtual void ModifyStamina() { }

}
