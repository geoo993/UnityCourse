using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizards : MonoBehaviour {

    int choice;
	int max;
	int min;
    int guess;

    void Start()
    {
        StartGame();
    }
    
    void StartGame(){
        max = 1000;
        min = 1;
        
        choice = Random.Range(1, 1000);
        
        
        print("===============================");
        print("Welcome to Number wizards");
        print("Pick a number in your head, but don't tell me!");

        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);
        
		print("You have chosen " + choice);

        
		max += 1;
	}
    
    
    void Update () {
    
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            //print("Up arrow pressed");
			min = guess;
            NextGuess();
        }else if (Input.GetKeyDown(KeyCode.DownArrow)){
            //print("Down arrow pressed");
		    max = guess;
            NextGuess();
        }else if (Input.GetKeyDown(KeyCode.Return)) {
            StartGame();
        }
    }
    
    bool CheckChoice(){
    
		if (guess == choice)
		{
			print("I found the number" + choice);
            return true;
		}else if (min > choice){
            print("Game Over, I cant search the number anymore " + choice);
            return false;
        }

        return false;
    }
    
    void NextGuess(){
       
         guess = (max + min) / 2;

        if (CheckChoice() == false)
        {
            print("Is the number higher or lower than " + guess + "?");
            print("Up arrow = higher, down = lower, return = equal");
        }
        
	}
    
}
