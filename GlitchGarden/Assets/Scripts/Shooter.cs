using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    
	// Use this for initialization
	void Start () {
        projectileParent = GameObject.Find("Projectiles");
        
        if (projectileParent == null){
            projectileParent = new GameObject("Projectiles");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void Fire(){

        GameObject proj = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        proj.transform.parent = projectileParent.transform;
    }
    
}
