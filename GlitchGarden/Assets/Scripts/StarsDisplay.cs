using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarsDisplay : MonoBehaviour {

    private Text starsText;
    private int starsCollected = 100;

    public enum Status { SUCCESS, FAILURE };
    
    
	// Use this for initialization
	void Start () {
		starsText = GetComponent<Text>();
        UpdateDisplay();
	}
	
    public void AddStars(int amount){
       
        starsCollected += amount;
        print("Number of stars: " + starsCollected);
        UpdateDisplay();
            
    }
    
    public Status UseStars(int amount){
        if (starsCollected >= amount)
        {
            starsCollected -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
    }
    
    void UpdateDisplay(){
        if (starsText)
        {
            starsText.text = starsCollected.ToString();
        }
    }
    
}
