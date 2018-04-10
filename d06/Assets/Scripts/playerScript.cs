using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {

	private CharacterController controller;
	public float moveSpeed;
	public float rotSpeed;
	public int discretion;
	public GameObject white;
	public GameObject red;
	private Image whiteBar;
	private Image redBar;
	public GameObject fan;
	public GameObject smoke;
	public bool smoking;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		whiteBar = white.GetComponent<Image>();
		redBar = red.GetComponent<Image>();
		moveSpeed = 5;
		rotSpeed = 3;
		discretion = 0;
		smoking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, Vector3.forward)){
			smoking = true;
		}

		if (smoking)
			smoke.GetComponent<ParticleSystem>().Play();
		else
			smoke.GetComponent<ParticleSystem>().Stop();
		
		if (discretion > 2)
			discretion-=2;
		
		if (discretion > 750) {
			redBar.fillAmount = (float)(discretion - 750) / 250f;
		} else {
			whiteBar.fillAmount = (float)discretion / 1000f;
			redBar.fillAmount = 0;
		}
		if (Input.GetKey(KeyCode.LeftShift)) {
			moveSpeed = 10;
			discretion+=10;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			moveSpeed = 5;
		}
		if (Input.GetKey(KeyCode.W))
			controller.SimpleMove(transform.TransformDirection(Vector3.forward) * moveSpeed);
		if (Input.GetKey(KeyCode.A))
			controller.SimpleMove(transform.TransformDirection(Vector3.left) * moveSpeed);
		if (Input.GetKey(KeyCode.S))
			controller.SimpleMove(transform.TransformDirection(Vector3.back) * moveSpeed);
		if (Input.GetKey(KeyCode.D))
			controller.SimpleMove(transform.TransformDirection(Vector3.right) * moveSpeed);

		float dir_x = transform.localEulerAngles.x;
		float dir_y = transform.localEulerAngles.y;
		transform.eulerAngles = new Vector3(dir_x - Input.GetAxis("Mouse Y") * rotSpeed,
											dir_y + Input.GetAxis("Mouse X") * rotSpeed,
											0);	
	}

	void OnTriggerStay(Collider collider){
		if (collider.tag == "cam") {
			discretion+=20;
		}
		if (collider.tag == "smoke" && smoking)
			discretion-=17;
	}
}