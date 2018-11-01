using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	public string game= "LabyrinthMinimal";

	// Use this for initialization
	void Start () {
		Debug.Log("Created");
	}

	// Update is called once per frame
	void Update () {}

	public void OnMouseUp(){
		Debug.Log("on mouse up entered");
		SceneManager.LoadScene("LabyrinthMinimal");
	}

}
