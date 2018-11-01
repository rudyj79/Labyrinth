using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Traps : PlayerPowers
{
    private int trapsLeft = 5;
    private GameObject trap;
    public Text trapText;
    public GameObject trapPrefab;

    void Start()
    {
        trapText = GameObject.Find("TrapText").GetComponent<Text>();
    }

    public override void GetUniqueAbility(){
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
}
