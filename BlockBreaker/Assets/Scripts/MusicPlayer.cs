using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    // Use this for initialization
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
