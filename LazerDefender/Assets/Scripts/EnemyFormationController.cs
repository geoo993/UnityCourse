using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormationController: MonoBehaviour {

    public GameObject enemyPrefab;

    public float width = 20.0f;
    public float height = 5.0f;
    public float speed = 5.0f;
    public float spawnDelay = 1.0f;

    private bool isMovingRight = true;
	private float xMin;
    private float xMax;
    
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height , 0.0f));
        
    }
    
    // Use this for initialization
    void Start () {

        CalculateScreenEdges();

        this.transform.position = new Vector3(width * 0.5f, this.transform.position.y, 0.0f);
        SpawnUntilFull();
    }
    
	// calculate screen edges
    void CalculateScreenEdges(){
    
        // distance between camera and player
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        
        // relative distance on left of the camera in x is 0.0f which gets the minimum width or left most value
        Vector3 leftBoundaryPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, distance));
        
        // relative distance on right of the camera in x is 1.0f which gets the maximum width or right most value
        Vector3 rightBoundaryPosition = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, distance));

        xMin = leftBoundaryPosition.x + (width * 0.5f);
        xMax = rightBoundaryPosition.x - (width * 0.5f);
    }
    
    // Update is called once per frame
    void Update () {
        Vector3 position = this.transform.position;
        
        if (isMovingRight){
			position += Vector3.right * speed * Time.deltaTime; 
        }else{
            position += Vector3.left * speed * Time.deltaTime; 
        }

        if (position.x <= xMin){
            isMovingRight = true;
        }else if (position.x >= xMax){
            isMovingRight = false;
        }

        this.transform.position = position;


        if (AllMembersDead()){
            //SpawnUntilFull();
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            levelManager.LoadNextLevel();
        }
        
	}
    
    void SpawnUntilFull(){
        Transform freePosition = NextFreePosition();

        if (freePosition != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
            enemy.transform.parent = freePosition; // set its parent
        }

        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }
    
    
    Transform NextFreePosition(){
        Transform nextPosition = null;

        foreach (Transform childPositionObject in transform)
        {
            if (childPositionObject.childCount <= 0){
                nextPosition = childPositionObject;
                break;
            }
        }
        
        return nextPosition;
    }
    
    bool AllMembersDead(){

        bool hasChild = true;
        
        foreach (Transform childPositionObject in transform){
            if (childPositionObject.childCount > 0) {
                hasChild = false;
                break;
            }
        }
        
        return hasChild;
    }
    
    void SpawnEnemies(){
        foreach (Transform child in transform){
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child.transform; // set its parent
        }
        
    }
    
    
    
}
