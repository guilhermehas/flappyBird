using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

    private Rigidbody2D rb;
    private float velocityUp = 7;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !GameController.instance.gameOver)
        {
            rb.velocity = new Vector2(0,velocityUp);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            rb.velocity = Vector2.zero;
        GameController.instance.BirdDied();
    }
}
