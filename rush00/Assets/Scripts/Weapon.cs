using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public GameObject	bullet;
	public Sprite		upSprite;
	public Sprite		downSprite;
	public AudioClip 	shotSound;
	public float		fireRate;
	public int			nbBullets;
	public string		wname;
	[HideInInspector] public float		_lastShot;
	private	Rigidbody2D	_rigidbody;
	private bool		_throwing;
	private int			_i;

	// Use this for initialization
	void Start () {
		_lastShot = 0;
		_rigidbody = gameObject.GetComponent<Rigidbody2D>();
		_i = 0;
		_throwing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (_throwing) {
			gameObject.transform.Rotate(0, 0, 20);
			_rigidbody.AddRelativeForce(new Vector2(10, 0));
			_i++;
		}

		if (_i >= 10) {
			_i = 0;
			_throwing = false;
		}
	}

	// Tirer, puis la balle se gere toute seule dans un script a part.
	public void fire(GameObject player) {
		if (Time.time - _lastShot >= fireRate && nbBullets != 0) {
			Quaternion rotation = player.transform.rotation;
			rotation.z += 90;

			Instantiate(bullet, player.transform.position, rotation);
			_lastShot = Time.time;
			if (nbBullets > 0)
				nbBullets--;
		}
	}

	public void fire(GameObject player, AudioSource audio) {
		if (Time.time - _lastShot >= fireRate && nbBullets != 0) {
			Quaternion rotation = player.transform.rotation;
			rotation.z += 90;

			Instantiate(bullet, player.transform.position, rotation);
			_lastShot = Time.time;
			if (nbBullets > 0)
				nbBullets--;

			audio.clip = shotSound;
			audio.Play();
		}
	}

	public void throwing(GameObject player) {
		_throwing = true;
	}
}
