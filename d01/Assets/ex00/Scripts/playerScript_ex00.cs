using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {

	public GameObject player;
	public bool isPlayed;

	// Use this for initialization
	void Start () {
		setIsPlayed(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayed) {
		   	if (Input.GetKey("left"))
				player.GetComponent<Rigidbody2D>().velocity = new Vector2(-5,
								player.GetComponent<Rigidbody2D>().velocity.y);
			else if (Input.GetKey("right"))
				player.GetComponent<Rigidbody2D>().velocity = new Vector2(5,
								player.GetComponent<Rigidbody2D>().velocity.y);
			else
				player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,
								player.GetComponent<Rigidbody2D>().velocity.y);				
			if (Input.GetKeyDown("space"))
				player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 5);
		}
	}

	public void setIsPlayed(bool value) {
		isPlayed = value;
		if (isPlayed) {
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		} else {
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX 
														   	 | RigidbodyConstraints2D.FreezeRotation;		  	
		}
	}
}
