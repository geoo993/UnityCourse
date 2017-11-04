using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    public GameObject parent;
    private StarsDisplay starsDisplay;
    
    // Use this for initialization
    void Start()
    {
        starsDisplay = FindObjectOfType<StarsDisplay>();
        parent = GameObject.Find("Defenders");
        
        if (parent == null){
            parent = new GameObject("Defenders");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        GameObject selectedDefender = Button.selectedDefender;

        if (selectedDefender)
        {
            Vector2 rawPos = CalculateWorldPointOfMouseClick();
            Vector2 roundedPos = SnapToGrid(rawPos);
            int defenderCost = selectedDefender.GetComponent<Defenfer>().starsCost;
            if (starsDisplay.UseStars(defenderCost) == StarsDisplay.Status.SUCCESS)
            {
                SpawnDefender(selectedDefender, roundedPos);
            }else{
                Debug.Log("Insufficient Stars to spawn");
            }
        }
    }

    void SpawnDefender(GameObject defender, Vector2 position)
    {
        GameObject spawner = Instantiate(defender, new Vector3(position.x, position.y, 0.0f), Quaternion.identity) as GameObject;
        spawner.name = defender.name;
        spawner.transform.parent = parent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPosition){
        return new Vector2(Mathf.RoundToInt(rawWorldPosition.x), Mathf.RoundToInt(rawWorldPosition.y));
    }
    
    Vector2 CalculateWorldPointOfMouseClick(){
        Vector2 mousePosition = Input.mousePosition;
        float distanceFromCamera = 10.0f;

        Vector3 triplet = new Vector3(mousePosition.x, mousePosition.y, distanceFromCamera);
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(triplet);
        
        return worldPoint;
    }
    
    
}
