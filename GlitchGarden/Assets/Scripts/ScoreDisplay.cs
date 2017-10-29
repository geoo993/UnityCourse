using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
        Text text = this.GetComponent<Text>();
        text.text = "You Earned "+ ScoreKeeper.score +" points";
        ScoreKeeper.Reset();
	}
	    
}
