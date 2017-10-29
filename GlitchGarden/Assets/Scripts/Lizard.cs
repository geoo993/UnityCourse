using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        if (!obj.GetComponent<Defenfer>()){
            return;
        }

        anim.SetBool("IsAttacking", true);
        attacker.Attack(obj);
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    
    
}
