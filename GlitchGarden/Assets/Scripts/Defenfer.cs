using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenfer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name + " on Trigger Enter");   
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    
}
