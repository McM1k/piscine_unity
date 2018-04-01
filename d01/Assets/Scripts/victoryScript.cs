using System;
using UnityEngine.SceneManagement;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoryScript : MonoBehaviour {

	public GameObject trigger;
	private static bool redOk;
	private static bool yellowOk;
	private static bool blueOk;

	// Use this for initialization
	void Start () {
		redOk = false;
		yellowOk = false;
		blueOk = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (redOk && yellowOk && blueOk)
		 	goToNextLevel();
	}

	void OnTriggerEnter2D(Collider2D player) {
		if (player.name == "red" && trigger.name == "red_exit")
		 	redOk = true;
		if (player.name == "yellow" && trigger.name == "yellow_exit")
		   	yellowOk = true;
		if (player.name == "blue" && trigger.name == "blue_exit")
		   	blueOk = true;
	}

	void OnTriggerExit2D(Collider2D player) {
		if (player.name == "red" && trigger.name == "red_exit")
		 	redOk = false;
		if (player.name == "yellow" && trigger.name == "yellow_exit")
		   	yellowOk = false;
		if (player.name == "blue" && trigger.name == "blue_exit")
		   	blueOk = false;		 	
	}

	public static void goToNextLevel(){
		int current = SceneManager.GetActiveScene().buildIndex;
		if (current >= SceneManager.sceneCount - 1)
		 	Application.LoadLevel(0);
		else
			Application.LoadLevel(current + 1);
	}
}
