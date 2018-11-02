using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPowers : MonoBehaviour
{

    Dictionary<string, Del> dict = new Dictionary<string, Del>();
    public string powerName = "";
    public delegate void Del();
    private int trapsLeft = 5;
    private float speedBoost = 50f;
    private GameObject trap;
    public Text trapText;
    public GameObject trapPrefab;
    [SerializeField] private PlayerMovement player;

    void Awake()
    {
        MakeDelegates();
    }

    void Update()
    {
        GetUniqueAbility();
    }

    public void GetUniqueAbility()
    {
        Del power;
        if (dict.TryGetValue(powerName, out power))
        {
            power();
        }
    }

    public void Artemis()
    {
        if (powerName == "artemis")
        {
            trapText.text = "Traps: " + trapsLeft;
            if (Input.GetKeyDown("o") && trapsLeft > 0)
            {
                trap = Instantiate(trapPrefab) as GameObject;
                trap.transform.position = this.transform.TransformPoint(0, -1.1f, 4);
                trapsLeft--;
                Destroy(trap, 15);
            }
        }
    }
    public void Hermes()
    {
        if (powerName == "hermes")
        {
            player.SetHermesSpeed(speedBoost);
        }
    }
    public void Hates()
    {
        if (powerName == "hates")
        {
            Debug.Log("Getting power");
        }
    }
    public void Poseidon()
    {
        if (powerName == "poseidon")
        {
            Debug.Log("Getting power");
        }
    }

    public void SetPowers(string theName){
        this.powerName = theName;
    }

    public void MakeDelegates(){
        Del artemis = Artemis;
        Del hates = Hates;
        Del hermes = Hermes;
        Del poseidon = Poseidon;
        dict.Add("artemis", artemis);
        dict.Add("hates", hates);
        dict.Add("hermes", hermes);
        dict.Add("poseidon", poseidon);
    }
}