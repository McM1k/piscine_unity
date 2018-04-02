using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	public GameObject	weapon;
	private GameObject	_weap;

	// Use this for initialization
/*	void Start () {
		_weap = Instantiate(weapon, Vector3.zero, Quaternion.identity);
		//weapon.GetComponent<Weapon>().lastShot = 0;
		_weap.SetActive(false);
	}
*/	
	// Update is called once per frame
	void Update () {
/*		if (Input.GetMouseButtonDown(0) && _weap) {
			_weap.GetComponent<Weapon>().fire(gameObject);
		}

		if (Input.GetMouseButtonDown(1) && _weap) {
			_weap.SetActive(true);
			_weap.GetComponent<Weapon>().throwing(gameObject);
			_weap = null;

		}
*/
	}
}
