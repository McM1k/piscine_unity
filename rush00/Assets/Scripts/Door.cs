using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public GameObject pivot;
	private Rigidbody2D	_door;
	// Use this for initialization
	void Start () {
		_door = GetComponent<Rigidbody2D>();
		Debug.Log(gameObject.transform.position);
		Debug.Log(_door.centerOfMass);
		//_door.centerOfMass = pivot.transform.position;
	}

	void Update() {
		//_door.centerOfMass = pivot.transform.position;
	}
}
