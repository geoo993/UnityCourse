using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    public Text text;
    private int choice;
	private int max;
	private int min;
    private int guess;
    private int maxGuesses;

    // user this in the new scene to find what you saved from the last scene
    private GameObject gameManagerPersistingObject;
    public GameManager manager;
    
    void Awake()
    {
        gameManagerPersistingObject = GameObject.Find("GameManager");
        manager = gameManagerPersistingObject.GetComponent<GameManager>();
        
        min = manager.minGuess;
        max = manager.maxGuess;
        maxGuesses = manager.maxGuesses;
    } 

    void Start()
    {
        StartGame();
    }
    
    void StartGame(){
       
        //choice = Random.Range(1, 1000);
        NextGuess();
	}
    
    
    void Update () {
    
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            //print("Up arrow pressed");
            //GuessHigher();
        }else if (Input.GetKeyDown(KeyCode.DownArrow)){
            //print("Down arrow pressed");
            //GuessLower();
        }else if (Input.GetKeyDown(KeyCode.Return)) {
            StartGame();
        }
    }
    
    public void GuessHigher(){
        min = guess;
        NextGuess();
    }
    
    public void GuessLower(){
		max = guess;
		NextGuess();
    }
    
    bool CheckEndGame(){
    
    /*
		if (guess == choice)
		{
			print("Computer found the number" + choice);
            SceneManager.LoadScene("Lose");
            return true;
		}else if (min > choice){
            print("Game Over, I cant search the number anymore " + choice);
            SceneManager.LoadScene("Lose");
            return true;
        }else 
        */
        if(maxGuesses <= 0){
            print("The Computer reached the maximum number of guesses");
            SceneManager.LoadScene("Win");
            return true;
        }
        

        return false;
    }
    
    void NextGuess(){

        guess = Random.Range(min, max+1);//(max + min) / 2;
        text.text = "" + guess;
        maxGuesses -= 1;
        
        
        if (CheckEndGame() == false)
        {
            //print("Is the number higher or lower than " + guess + "?");
            //print("Up arrow = higher, down = lower, return = equal");
        }
        
	}
    
}
