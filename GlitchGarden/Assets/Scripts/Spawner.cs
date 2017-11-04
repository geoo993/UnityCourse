using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackersPrefabs;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
        foreach(GameObject attacker in attackersPrefabs){
            if (IsTimeToSpawn(attacker)){
                Spawn(attacker);
            }
        }
        
	}
    
    bool IsTimeToSpawn(GameObject attacker){
        Attacker attackerObj = attacker.GetComponent<Attacker>();
        float spawnDelay = attackerObj.seenEverySeconds;
        float spawnPerSecond = 1.0f / spawnDelay;
        float numberOfLanes = 5.0f;
        
        if (Time.deltaTime > spawnDelay){
            Debug.LogWarning("Spawn Rate capped by frame rate");
        }

        float threshold = spawnPerSecond * Time.deltaTime / numberOfLanes;

        return (Random.value < threshold);
    }
    
    void Spawn(GameObject attacker){
        GameObject spawner = Instantiate(attacker, transform.position, Quaternion.identity) as GameObject;
        spawner.name = attacker.name;
        spawner.transform.parent = transform;
    }
    
}
