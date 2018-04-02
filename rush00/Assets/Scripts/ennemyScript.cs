using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ennemyScript : MonoBehaviour {

	public GameObject weapon;
	public AudioClip deathSound;
	private Rigidbody2D rb;
	private Animator animator;
	private AudioSource audio;
	
	public enum State{
		IDLE,
		MOVE,
		SEARCH,
		DEAD
	};
	public State state;
	// Use this for initialization
	void Start () {
		Debug.Log("SHOT");
		rb = GetComponent<Rigidbody2D>();
		animator = transform.GetChild(1).GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
		state = State.IDLE;
		weapon.GetComponent<Weapon>()._lastShot = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (State.MOVE == state) {
			weapon.GetComponent<Weapon>().fire(gameObject, audio);
		}
	}

	void OnTriggerStay2D(Collider2D seenByEnemy){
		if (seenByEnemy.gameObject.tag == "Player" && state != State.DEAD) {
			Vector3 target = seenByEnemy.transform.position;
			target = target - transform.position;
			float alpha = (float)Math.Atan2(target.y, target.x);
			transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * alpha + 90);
			rb.AddRelativeForce(new Vector2(0, -40));
			changeState(State.MOVE);
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		changeState(State.IDLE);
	}

	void changeState(State newState) {
		if (state != newState) {
			if (newState == State.IDLE && state != State.DEAD) {
				animator.Play("idle");
				state = newState;
			}
			if (newState == State.MOVE) {
				animator.Play("move");
				state = newState;
			}
			if (newState == State.SEARCH) {
				animator.Play("move");
				state = newState;
			}
			if (newState == State.DEAD) {
				animator.Play("idle");
				audio.clip = deathSound;
				audio.Play();
				state = newState;
				StartCoroutine(onDestroy());
			}
		}
	}

	IEnumerator onDestroy() {
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		weapon.GetComponent<Weapon>()._lastShot = 0;
        if (other.gameObject.tag == "Bullet") {
			changeState(State.DEAD);
		}
    }
}
