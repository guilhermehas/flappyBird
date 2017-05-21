using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {
    private Rigidbody2D rb;
    private float velocityX = 5f;
    private float positionX = -15f;
    public static float deltaX = 60f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocityX, 0);
        //rb.position = new Vector2(rb.position.x, Random.Range(-6, -3));
		
	}

	// Update is called once per frame
	void Update () {
        if (GameController.instance.gameOver == true)
            rb.velocity = Vector2.zero;

        if (rb.position.x < positionX)
        {
            //rb.position = new Vector2(deltaX + rb.position.x, -0.5f);
            //Debug.Log(rb.position.y);
            rb.position = new Vector2(deltaX + rb.position.x, Random.Range(-0.5f,3.16f));
        }
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<BirdScript>() != null)
            GameController.instance.scoreAdd();
    }
}
