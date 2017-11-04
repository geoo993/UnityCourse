using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))] 
[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
	public static GameObject selectedDefender; // mean sone of them in the entire game
    
    private Button[] buttons;
    private Text costText;
    
	// Use this for initialization
	void Start () {
        buttons = FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        if (costText == null){
            Debug.LogWarning(name + " has no cost Text object");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (costText){
            costText.text = defenderPrefab.GetComponent<Defenfer>().starsCost.ToString();
        }
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
