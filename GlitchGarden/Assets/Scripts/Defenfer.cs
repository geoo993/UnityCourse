using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenfer : MonoBehaviour {

    [Range(0, 100)]
    public int starsCost = 10;
    private StarsDisplay starsDisplay;
    
	// Use this for initialization
	void Start () {
        starsDisplay = FindObjectOfType<StarsDisplay>();
	}
	
    public void AddStars(int amount){
        starsDisplay.AddStars(amount);
    }
    
}
