using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cameraScript : MonoBehaviour {

private CharacterController controller;
	public float moveSpeed;
	public float rotSpeed;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		moveSpeed = 100;
		rotSpeed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
			controller.SimpleMove(transform.TransformDirection(Vector3.forward) * moveSpeed);
		if (Input.GetKey(KeyCode.A))
			controller.SimpleMove(transform.TransformDirection(Vector3.left) * moveSpeed);
		if (Input.GetKey(KeyCode.S))
			controller.SimpleMove(transform.TransformDirection(Vector3.back) * moveSpeed);
		if (Input.GetKey(KeyCode.D))
			controller.SimpleMove(transform.TransformDirection(Vector3.right) * moveSpeed);
		if (Input.GetKey(KeyCode.Q))
			controller.SimpleMove(transform.TransformDirection(Vector3.down) * moveSpeed);
		if (Input.GetKey(KeyCode.E))
			controller.SimpleMove(transform.TransformDirection(Vector3.up) * moveSpeed);

		float dir_x = transform.localEulerAngles.x;
		float dir_y = transform.localEulerAngles.y;
		transform.eulerAngles = new Vector3(dir_x - Input.GetAxis("Mouse Y") * rotSpeed,
											dir_y + Input.GetAxis("Mouse X") * rotSpeed,
											0);	
	}
}
