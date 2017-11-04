using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelmanager;
    
	// Use this for initialization
	void Start () {
        levelmanager = FindObjectOfType<LevelManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelmanager)
        {
            Destroy(collision.gameObject);
            levelmanager.LoadLevel("Lose");
        }
    }
    
}
