using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public bool useMouse = true;
    public float minX = 0.5f;
    public float maxX = 14.2f;
    
    private float mousePosInBlock;
    private Ball ball;

    [Range(0.0f, 2.0f)] public float keyPressSpeed = 0.5f;
    private float keyPress;
    
	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
        keyPress = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            if (useMouse){
				MoveWithMouse();
            }else{
				MoveWithKeyDown();
            }
        }else{
            AutoPlay();
        }
    }

    void MoveWithKeyDown()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            keyPress -= keyPressSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow)){
            keyPress += keyPressSpeed;
        }
        
        keyPress = Mathf.Clamp(keyPress, minX, 14.2f);
        
        Vector3 currentPosition = this.transform.position;
        currentPosition.x = keyPress;
        this.transform.position = currentPosition; 

    }
    
    void MoveWithMouse(){
    
		Vector3 currentPosition = this.transform.position;
		
		//print(Input.mousePosition.x / Screen.width); // mouse position in 0 to 1 unit
		//print(Input.mousePosition.x / Screen.width * 16); // mouse position in game unit (0 - 16)
		mousePosInBlock = Input.mousePosition.x / Screen.width * 16;
		currentPosition.x = Mathf.Clamp(mousePosInBlock, minX, maxX);
		this.transform.position = currentPosition;   
    }
    
    void AutoPlay(){
        Vector3 currentPosition = this.transform.position;
        Vector3 ballPosition = ball.transform.position;
        currentPosition.x = Mathf.Clamp(ballPosition.x, minX, maxX);
        this.transform.position = currentPosition; 
    
    }
    
}
