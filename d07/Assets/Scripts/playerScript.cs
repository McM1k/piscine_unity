using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {
	public ParticleSystem particle;
	private GameObject tank;
	private GameObject cannon;
	private GameObject camera;
	private GameObject shoot;
	private int stamina;
	private int ammo;
	// Use this for initialization
	void Start () {
		tank = transform.GetChild(0).GetChild(0).gameObject;
		cannon = transform.GetChild(1).gameObject;
		camera = transform.GetChild(1).GetChild(1).gameObject;
		shoot = transform.GetChild(1).GetChild(2).gameObject;
		stamina = 200;
		ammo = 20;
	}
	
	// Update is called once per frame
	void Update () {
		camera.transform.LookAt(cannon.transform.position);

		if (Input.GetKey(KeyCode.W))
			tank.GetComponentInParent<Rigidbody>().MovePosition(transform.position + transform.forward * 0.3f);
		else if (Input.GetKey(KeyCode.S))
			tank.GetComponentInParent<Rigidbody>().MovePosition(transform.position + transform.forward * -0.3f);
		if (Input.GetKey(KeyCode.A))
			tank.GetComponentInParent<Rigidbody>().MoveRotation(Quaternion.Euler(0, -3f, 0) * tank.transform.rotation);
		else if (Input.GetKey(KeyCode.D))
			tank.GetComponentInParent<Rigidbody>().MoveRotation(Quaternion.Euler(0, 3f, 0) * tank.transform.rotation);

		cannon.transform.Rotate(0,Input.GetAxis("Mouse X") * 3f,0);
		
		if (Input.GetKey(KeyCode.LeftShift) && stamina > 2) {
			stamina-= 3;
			tank.GetComponentInParent<Rigidbody>().MovePosition(transform.position + transform.forward * 1f);
		}
		else if (stamina < 200)
			stamina++;

		if (Input.GetMouseButtonDown(1) && ammo > 0) {
			RaycastHit target;
			Physics.Raycast(shoot.transform.position, cannon.transform.forward, out target, 100);
			ParticleSystem.EmitParams param = new ParticleSystem.EmitParams();
			param.position = target.point;
  			particle.Emit(param, 200);
			ammo--;
		}

		if (Input.GetMouseButton(0)) {
			RaycastHit target;
			Physics.Raycast(shoot.transform.position, cannon.transform.forward, out target, 100);
			ParticleSystem.EmitParams param = new ParticleSystem.EmitParams();
			param.position = target.point;
  			particle.Emit(param, 3);
		}
	}
}
