using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Vector3		_dest;
	private Rigidbody2D	_rb;
	private Vector3		_target;
	// Use this for initialization
	void Start () {
		_dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		_rb = GetComponent<Rigidbody2D>();

		_target = _dest;
		_target = _target - transform.position;
		float alpha = (float)Mathf.Atan2(_target.y, _target.x);
		transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * alpha);
	}
	
	// Update is called once per frame
	void Update () {
		_rb.AddRelativeForce(new Vector2(300, 0));
	}

	void OnCollisionEnter2D(Collision2D other) {
		Destroy(gameObject);
	}
}
