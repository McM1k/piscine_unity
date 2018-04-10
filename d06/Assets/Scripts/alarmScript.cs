using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class alarmScript : MonoBehaviour {

	public GameObject player;
	public AudioSource audio;
	private playerScript script;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		script = player.GetComponent<playerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (script.discretion > 1000) {
			SceneManager.LoadScene(0);
		}
		if (script.discretion > 750) {
			if (!audio.isPlaying)
				audio.Play();
		}
		else {
			audio.Stop();
		}
	}
}
