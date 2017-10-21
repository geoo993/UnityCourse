using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    private Vector3 paddleToBallVector = Vector3.zero;
    private bool hasStarted = false;

    void Awake()
    {
        paddle = FindObjectOfType<Paddle>();
        
    }
    
    // Use this for initialization
    void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
    
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();

        if (!hasStarted)
        {
            // lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // wait for a mouse press to launch
            if (Input.GetMouseButtonDown(0))
            {
                //print("Mouse Clicked");
                LaunchBall(rigidBody);
            }

            if (Input.GetKeyDown(KeyCode.Space)){
                //print("Space Pressed");
                LaunchBall(rigidBody);
            }
            
        }
        
    }
    
    void LaunchBall(Rigidbody2D rb){
        rb.velocity = new Vector2(2.0f, 10.0f);
		hasStarted = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));
        
        if (hasStarted)
        {
            //this.GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

}
