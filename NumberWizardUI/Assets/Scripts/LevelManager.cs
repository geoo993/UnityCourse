using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
        Debug.Log("level load requested for "+ name );
        //int scene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(scene, LoadSceneMode.Single);

        SceneManager.LoadScene(name);
    }
    
    public void QuitLevel(){
        Debug.Log("quit level requested" );
        Application.Quit();
    }
}
