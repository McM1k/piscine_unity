using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class placeTurret : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public GameObject turret;
	public GameObject gameManager;
	private Vector3 startPos;
	private Vector3 mousePos;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
   
    public void OnBeginDrag(PointerEventData eventData)
    {
		if (gameManager.GetComponent<gameManager>().playerEnergy >= turret.GetComponent<towerScript>().energy) {
        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.
			startPos = transform.position;
		}
    }

    public void OnDrag(PointerEventData eventData)
    {
		if (gameManager.GetComponent<gameManager>().playerEnergy >= turret.GetComponent<towerScript>().energy) {
			mousePos = Input.mousePosition;
			transform.position = mousePos;
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			GameObject tile = hit.collider.gameObject;
			if (tile && tile.tag == "empty")
				GetComponent<Image>().color = Color.green;
			else
				GetComponent<Image>().color = Color.red;
		}
		else
			GetComponent<Image>().color = Color.red;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
		if (gameManager.GetComponent<gameManager>().playerEnergy >= turret.GetComponent<towerScript>().energy) {
			transform.position = startPos;
		//xheck if can be placed
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			GameObject tile = hit.collider.gameObject;
			if (tile && tile.tag == "empty"){
				GameObject.Instantiate(turret, tile.transform.position, Quaternion.identity);
				gameManager.GetComponent<gameManager>().playerEnergy -= turret.GetComponent<towerScript>().energy;
				Destroy(tile);
			}
		}
		GetComponent<Image>().color = Color.white;
	}
}
