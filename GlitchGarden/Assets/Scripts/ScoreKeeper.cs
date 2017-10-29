using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    private Text text;
    public static int score;
    
	void Start()
	{
		text = GetComponent<Text>();
        text.text = "Score: " + score;
	}
    
    public void Score (int points) {
        score += points;
		text.text = "Score: " + score;
    }

    public static void Reset()
    {
        score = 0;
    }

}
