using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public GameObject ball;
	public GameObject lastPos;
	public int charge;
	public int speed;
	public bool goUp;
	public int score;

	// Use this for initialization
	void Start () {
		charge = 0;
		speed = 0;
		goUp = true;
		score = -15;
	}
	
	// Update is called once per frame
	void Update () {
		if (speed == 0)
		   	lastPos.transform.position = ball.transform.localPosition;

		if (Input.GetKey("space") && speed == 0){
			charge+=10;
		} else if (charge > 0){
			speed +=charge;
			charge = 0;
			score+=5;
			Debug.Log(score);
		}
		
		if (goUp) {
		   	ball.transform.Translate(0, (float)speed / 1000, 0);
			if (speed > 0)
		   	   	speed-=5;
		} else {
		   	ball.transform.Translate(0, -(float)speed / 1000, 0);
			if (speed > 0)
		   	   	speed-=5;
		}

		if (speed > 0) {
		   	if (ball.transform.localPosition.y >= 3.5)
		   	   	goUp = false;
			else if (ball.transform.localPosition.y <= -3.5)
				goUp = true;
		} else {
		  	if (ball.transform.localPosition.y > 2)
			   	goUp = false;
			else
				goUp = true;
		}
		
		if (speed < 50 && ball.transform.localPosition.y > 1.8 && ball.transform.localPosition.y < 2.2)
		   	GameObject.Destroy(ball);
	}
}
