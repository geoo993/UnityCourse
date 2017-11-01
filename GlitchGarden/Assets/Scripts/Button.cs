using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
	public static GameObject selectedDefender; // mean sone of them in the entire game
    
    private Button[] buttons;
    
	// Use this for initialization
	void Start () {
        buttons = FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
    }

    void OnMouseDown()
    {
        foreach (Button button in buttons){
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }
        
		GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
        
        
    }
}
