using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    [SerializeField, Range(10.0f, 100.0f)] private float damage = 100.0f;

    public float GetDamage(){
        return damage;
    }
    
    public void Hit(){
        Destroy(gameObject);
    }
}
