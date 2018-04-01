using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valuesToTurret : MonoBehaviour {

	public GameObject turret;
	public GameObject dmg_txt;
	public GameObject enr_txt;
	public GameObject rng_txt;
	public GameObject rld_txt;
	private int dmg;
	private int enr;
	private float rng;
	private float rld;

	// Use this for initialization
	void Start () {
		dmg = turret.GetComponent<towerScript>().damage;
		dmg_txt.GetComponent<Text>().text = dmg.ToString();
		enr = turret.GetComponent<towerScript>().energy;
		enr_txt.GetComponent<Text>().text = enr.ToString();
		rng = turret.GetComponent<towerScript>().range;
		rng_txt.GetComponent<Text>().text = rng.ToString();
		rld = turret.GetComponent<towerScript>().fireRate;
		rld_txt.GetComponent<Text>().text = rld.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
