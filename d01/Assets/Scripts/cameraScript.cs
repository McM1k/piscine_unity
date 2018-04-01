using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraScript : MonoBehaviour {

    public int player;
    public GameObject camera;
    public GameObject[] players;

    // Use this for initialization
    void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        player = 0;
		setCharManager(true);
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown("n"))
			victoryScript.goToNextLevel();		
	    if (Input.GetKeyDown("r"))
            Application.LoadLevel(SceneManager.GetActiveScene().name);

        if (Input.GetKeyDown("1")) {
			setCharManager(false);
            player = 0;
			setCharManager(true);
        }
        if (Input.GetKeyDown("2")) {
		   	setCharManager(false);
            player = 1;
			setCharManager(true);
        }
        if (Input.GetKeyDown("3")) {
			setCharManager(false);
            player = 2;
			setCharManager(true);
        }

        camera.transform.position = players[player].transform.position;
        camera.transform.Translate(0,0,-4);
    }

	void setCharManager(bool value) {
        if (SceneManager.GetActiveScene().name == "ex00")
            players[player].GetComponent<playerScript_ex00>().setIsPlayed(value);
		else if (SceneManager.GetActiveScene().name == "ex01" || SceneManager.GetActiveScene().name == "ex02")
           	players[player].GetComponent<playerScript_ex01>().setIsPlayed(value);
	}
}