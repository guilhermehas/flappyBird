using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour {

    private Rigidbody2D rb;
    private float velocityX = 5f;
    private float positionX = 27.30667f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocityX, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.instance.gameOver == true) 
            rb.velocity = Vector2.zero;
        

        if(rb.position.x < -positionX)
        {
            //Debug.Log("here");
            //Debug.Log(rb.position.x);
            rb.position = new Vector2(rb.position.x + 2*positionX, rb.position.y);
        }
	}
}
