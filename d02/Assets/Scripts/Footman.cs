using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Footman : MonoBehaviour {

	public GameObject human;
	private Vector3 mouseToWorld;
	private Animator animator;
	private AudioSource audio;
	public AudioClip[] sounds;

	public enum State {
		IDLE,
		SELECTED,
		MOVE
	};
	public State state;

	// Use this for initialization
	void Start () {
		mouseToWorld = human.transform.position;
		animator = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
	}
	

	// Update is called once per frame
	void Update () {
		if (state == State.IDLE) {
			animator.Play("idle");
		}
		else if (state == State.MOVE) {
			
			human.transform.position = Vector3.MoveTowards(human.transform.position, mouseToWorld, 0.05f);

			Vector3 direction = mouseToWorld - human.transform.position; // rotate towards destination
			float alpha = (float)Math.Atan2(direction.y, direction.x);
			human.transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * alpha - 90);
		}

		if (mouseToWorld == human.transform.position)
			ChangeState(State.IDLE);
	}

	public void ChangeState(State _state) {
		if (_state == State.IDLE) {
			state = State.IDLE;
		}
		else if (_state == State.SELECTED) {
			audio.clip = sounds[0];
			audio.Play();
			state = State.IDLE;
		}
		else if (_state == State.MOVE) {
			audio.clip = sounds[1];
			audio.Play();
			animator.Play("runN");
			mouseToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mouseToWorld.z = human.transform.position.z;

			state = State.MOVE;
		}
		
	}
}