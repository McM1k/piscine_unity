using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restart() {
		SceneManager.LoadScene("level2");
		Time.timeScale = 1;
	}

	public void Exit() {
		Application.Quit();
	}
}
