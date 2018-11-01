using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUpsDisplay : MonoBehaviour
{

    public Text myText;
    public GameObject powerUp;
    public EntranceDoorScript door;
    private bool powerApplied;
    private const int CLOSE_ENOUGH = 8;
    private const int HIGHEST_POINT = 8;
    [SerializeField] private float fadeTime;
    [SerializeField] private Transform player;
    [SerializeField] private Canvas display;
    public MinotaurController MinController;



    // Use this for initialization
    void Start()
    {
        myText = this.gameObject.GetComponent<Text>();
        myText.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (NearPowerUp())
        {
            ShowText();
            PickUpPowerUp();
        }
        else
        {
            DontShowText();
        }
        if (powerApplied)
        {
            FloatPowerUp();
        }
    }

    private bool NearPowerUp()
    {
        bool nearPowerUp = Vector3.Distance(player.position, this.transform.position) < CLOSE_ENOUGH;
        return nearPowerUp;
    }

    void ShowText()
    {
        display.transform.rotation = player.transform.rotation;
        myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
    }

    private void DontShowText()
    {
        myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
    }

    public void PickUpPowerUp()
    {
        if (Input.GetKeyDown("p"))
        {
            myText.text = "";
            ApplyPowerUp();
            DestroyOtherPowerUps();
            door.OpenDoor();
            powerApplied = true;
        }
    }

    void UnleashTheMinotaur()
    {
        MinController.FollowPlayer();
    }

    void FloatPowerUp(){
        if (powerUp.transform.position.y < HIGHEST_POINT)
        {
            powerUp.transform.Translate(0, Time.deltaTime, 0);
        }
        else
        {

            MinController.FollowPlayer();
            //Destroy(powerUp.gameObject);
        }
    }

    public virtual void ApplyPowerUp() { }
    public virtual void DestroyOtherPowerUps() { }

}
