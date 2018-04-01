using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {
	public int stamina;
	public float size;
	public GameObject balloon;

	// Use this for initialization
	void Start () {
		size = 1.0f;
		stamina = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		size -= 0.02f;
		if (stamina < 1000) {
		   stamina+=4;
		}
		
		if (Input.GetKeyDown("space") && stamina >= 150) {
		   size += 0.5f;
		   stamina -= 150;
		}
		balloon.transform.localScale = new Vector3(size, size, 1);

		if (balloon.transform.localScale.x < 0 || balloon.transform.localScale.x > 5) {
		   GameObject.Destroy(balloon);
		   Debug.Log(Time.time);
		}
	}
}