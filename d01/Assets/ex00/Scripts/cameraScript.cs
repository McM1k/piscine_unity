using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	public int player;
	
	public GameObject camera;
	public GameObject[] players;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		player = 0;
		players[player].GetComponent<playerScript_ex00>().setIsPlayed(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("r")) {
		   	Application.LoadLevel("ex00");
		}

		if (Input.GetKeyDown("1")) {
		   	players[player].GetComponent<playerScript_ex00>().setIsPlayed(false);
			player = 0;
			players[player].GetComponent<playerScript_ex00>().setIsPlayed(true);
		}
		if (Input.GetKeyDown("2")) {
		   	players[player].GetComponent<playerScript_ex00>().setIsPlayed(false);
			player = 1;
			players[player].GetComponent<playerScript_ex00>().setIsPlayed(true);
		}
		if (Input.GetKeyDown("3")) {
		   	players[player].GetComponent<playerScript_ex00>().setIsPlayed(false);
			player = 2;
			players[player].GetComponent<playerScript_ex00>().setIsPlayed(true);
		}

		camera.transform.position = players[player].transform.localPosition;
		camera.transform.Translate(0,0, -4);
	}
}
