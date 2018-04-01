using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {

	public GameObject club;
	public GameObject hole;
	public GameObject lastPos;
	public bool goUp;

	// Use this for initialization
	void Start () {
		goUp = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space")) {
		   	if (goUp)
				club.transform.Translate(0, -0.01f, 0);
			else
				club.transform.Translate(0, 0.01f, 0);
		}
		else {
			club.transform.position = lastPos.transform.localPosition;
			if (!goUp)
				club.transform.Translate(0, 1, 0);
		}

		if (lastPos.transform.localPosition.y > hole.transform.localPosition.y)
		   	goUp = false;
		else
			goUp = true;		
	}
}
