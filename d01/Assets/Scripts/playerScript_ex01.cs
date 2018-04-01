using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour {
    public GameObject player;
    public bool isPlayed;
    public float speed;
    public float jump;
    // Use this for initialization
    void Start () {
        setIsPlayed(false);
    }
    // Update is called once per frame
    void Update () {
        if (isPlayed) {
            if (Input.GetKey("left"))
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(- speed,
                                player.GetComponent<Rigidbody2D>().velocity.y);
            else if (Input.GetKey("right"))
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,
                                player.GetComponent<Rigidbody2D>().velocity.y);
            else
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,
                                player.GetComponent<Rigidbody2D>().velocity.y);
            if (Input.GetKeyDown("space") && player.GetComponent<Rigidbody2D>().velocity.y > -0.01 &&
			   							  	 player.GetComponent<Rigidbody2D>().velocity.y < 0.01)
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x,
                                                      jump);
        }
    }
    public void setIsPlayed(bool value) {
        isPlayed = value;
        if (isPlayed)
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        else
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX
                                                           | RigidbodyConstraints2D.FreezeRotation;
    }
}
