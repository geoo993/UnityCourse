using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    
    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator anim;
    private Spawner spawner;
    
	// Use this for initialization
	void Start () {
    
        anim = FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles");
        
        if (projectileParent == null){
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () {

        bool shouldAttack = IsAttackerInLane();
        if (anim)
        {
            anim.SetBool("IsAttacking", shouldAttack);
        }
	}
    
    void SetMyLaneSpawner(){
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach(Spawner obj in spawners){
            int objY = (int)(obj.transform.position.y);
            int transformY = (int)(transform.position.y);
            if (objY == transformY){
                spawner = obj;
                return;
            }
        }
        
        Debug.LogError(name + "Can't find spawner in lane");
    }
    
    bool IsAttackerInLane(){

        if (spawner == null || spawner.transform.childCount <= 0){
            return false;
        }

        bool attackersInLane = false;
        foreach (Transform attacker in spawner.transform){
            if (attacker.transform.position.x > transform.position.x){
                attackersInLane = true;
                break;
            }
        }

        return attackersInLane;
    }
    
    void Fire(){

        GameObject proj = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        proj.transform.parent = projectileParent.transform;
    }
    
}
