using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class playerScript : MonoBehaviour {

	public GameObject weapon;
	public AudioClip deathSound;
	public AudioClip pickSound;
	public AudioClip wooshSound;
	public AudioClip clickSound;
	public Text hudWeapon;
	public Text hudBullets;
	public GameObject endPanel;

	private Animator animator;
	private Vector3 mousePos;
	private Rigidbody2D rigidbody;
	private AudioSource audio;
	private bool dead;

	public enum State{
		IDLE,
		MOVE,
		DEAD
	};
	private State state;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		animator = transform.GetChild(2).GetChild(0).GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
		state = State.IDLE;
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && weapon) {
			if (weapon.GetComponent<Weapon>().nbBullets != 0) {
				audio.clip = weapon.GetComponent<Weapon>().shotSound;
				audio.Play();
			} else {
				audio.clip = clickSound;
				audio.Play();
			}
			weapon.GetComponent<Weapon>().fire(gameObject);
		}

		if (Input.GetMouseButtonDown(1) && weapon) {
			audio.clip = wooshSound;
			audio.Play();
			weapon.GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<Weapon>().downSprite;
			weapon.GetComponent<Weapon>().throwing(gameObject);
			weapon = null;
			hudWeapon.text = "No Weapon";
			hudBullets.text = "-";
		}

		if (weapon) {
			weapon.transform.position = new Vector3(transform.position.x,
													transform.position.y + 0.3f,
													transform.position.z);
			weapon.transform.rotation = transform.rotation;
			weapon.GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<Weapon>().upSprite;
		}

		if (Input.GetKey(KeyCode.LeftShift)) {
			Vector3 diff = transform.position + mousePos;
			Camera.main.transform.position = diff/2;
		}
		else
			Camera.main.transform.position = transform.position;
		Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10);

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = transform.position.z;
		Vector3 direction = mousePos - transform.position;
		float alpha = (float)Math.Atan2(direction.y, direction.x);
		transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * alpha + 90);

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
			Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
			changeState(State.MOVE);
		}
		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) &&
			!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) {
			changeState(State.IDLE);
		}

		if (Input.GetKey(KeyCode.W)) {
			rigidbody.AddForce(new Vector2(0, 100));
		}
		if (Input.GetKey(KeyCode.A)) {
			rigidbody.AddForce(new Vector2(-100, 0));
		}
		if (Input.GetKey(KeyCode.S)) {
			rigidbody.AddForce(new Vector2(0, -100));
		}
		if (Input.GetKey(KeyCode.D)) {
			rigidbody.AddForce(new Vector2(100, 0));
		}

		if (Input.GetKeyDown(KeyCode.E)) {
			Vector3 target = transform.position;
			RaycastHit2D[] hit = Physics2D.RaycastAll(target, Vector2.zero);
			int i = 0;
			while(i < hit.Length) {
				if (hit[i].collider.gameObject.tag == "Weapon") {
					equipWeapon(hit[i].collider.gameObject);
					break;
				}
				i++;
			}
		}
		if (weapon)
			hudBullets.text = weapon.GetComponent<Weapon>().nbBullets.ToString();
	}
	void changeState(State newState) {
		if (state != newState) {
			if (newState == State.IDLE) {
				animator.Play("idle");
				state = newState;
			}
			if (newState == State.MOVE) {
				animator.Play("move");
				state = newState;
			}
			if (newState == State.DEAD) {
				animator.Play("idle");
				audio.clip = deathSound;
				audio.Play();
				state = newState;
				Time.timeScale = 0;
				endPanel.SetActive(true);
			}
		}
	}
	void equipWeapon(GameObject newWeapon) {
		audio.clip = pickSound;
		audio.Play();
		weapon = newWeapon;
		hudWeapon.text = weapon.GetComponent<Weapon>().wname;
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.gameObject.tag == "EnnemyBullet")
			changeState(State.DEAD);
	}
}
