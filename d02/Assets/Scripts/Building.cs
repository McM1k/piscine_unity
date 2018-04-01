using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	public bool isMainBuilding;
	public int hp;
	private float time;
	public GameObject unitSpawned;
	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 10 && isMainBuilding) {
			GameObject.Instantiate(unitSpawned);
			time = 0;
		}
	}
}
