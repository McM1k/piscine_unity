using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	private Vector3		_dest;
	private Rigidbody2D	_rb;
	private Vector3		_target;
	private int			_i;
	// Use this for initialization
	void Start () {
		_dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		_rb = GetComponent<Rigidbody2D>();

		_target = _dest;
		_target = _target - transform.position;
		float alpha = (float)Mathf.Atan2(_target.y, _target.x);
		transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * alpha);
		_rb.AddRelativeForce(new Vector2(100, 0));
		_i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (_i >= 7)
			Destroy(gameObject);
		_rb.AddRelativeForce(new Vector2(100, 0));
		_i++;

	}

	void OnCollisionEnter2D(Collision2D other) {
		Destroy(gameObject);
	}
}
