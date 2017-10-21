using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //public int minGuess = 1;
    
    //public int maxGuess = 1000;

    //[Range(0, 20)] public int maxGuesses = 10;
    
	static GameManager instance = null;
    
    // Make this game object and all its transform children
    // survive when loading a new scene.
    void Awake () {
        if (instance != null){
            Destroy(gameObject);
            Debug.Log("Duplicate MusicPlayer self-destructed");
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

}
