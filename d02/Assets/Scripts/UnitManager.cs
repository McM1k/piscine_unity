using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

	private List<Footman> crowd = new List<Footman>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = -100f;
			RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

			if (hit) {
				if (!Input.GetKey(KeyCode.LeftControl)) // Add to selection
					crowd.Clear();
				crowd.Add(hit.collider.gameObject.GetComponent<Footman>());
				hit.collider.gameObject.GetComponent<Footman>().ChangeState(Footman.State.SELECTED);
			} else { // Order to Move
				foreach (Footman human in crowd)
					human.ChangeState(Footman.State.MOVE);
			}
		}

		if (Input.GetMouseButtonDown(1)) { // Throw list
			crowd.Clear();
		}
	}
}
