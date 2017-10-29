using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField, Range(0.0f, 100.0f)] private float health = 100.0f;
    
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Damage(float damage){
        health -= damage;
        if (health < 0){
            DestroyDyingObject();
        }
        
    }
    
    
    public void DestroyDyingObject(){
        Destroy(gameObject);
    }
    
    
}
