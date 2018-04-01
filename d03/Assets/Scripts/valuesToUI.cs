using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valuesToUI : MonoBehaviour {

	public GameObject gameManager;
	public GameObject hp_txt;
	public GameObject enr_txt;
	private int hp;
	private int enr;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hp = gameManager.GetComponent<gameManager>().playerHp;
		enr = gameManager.GetComponent<gameManager>().playerEnergy;
		hp_txt.GetComponent<Text>().text = hp.ToString();
		enr_txt.GetComponent<Text>().text = enr.ToString();	
	}
}
