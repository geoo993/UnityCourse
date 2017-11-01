using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float walkSpeed;
    private GameObject currentTarget;
    private Animator anim;
    
    private Rigidbody2D _rigidBody;
    private Rigidbody2D rigidBody{
        get{
            if (_rigidBody == null)
            {
                _rigidBody = gameObject.GetComponent<Rigidbody2D>();
            }
            return _rigidBody;
        }
        
        set{
            _rigidBody = value;
        }
    }
    
    void Awake()
    {
        rigidBody = gameObject.AddComponent<Rigidbody2D>();
		rigidBody.isKinematic = true;
    }
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        if (currentTarget == null){
            anim.SetBool("IsAttacking", false);
        }
        
        print(Button.selectedDefender);
	}
    
    public void SetSpeed(float speed){
        walkSpeed = speed;
    }
    
	// this is called from the animator at the time of the actual attack
    public void StrikeCurrentTarget(float damage){
        if (currentTarget)
        {
            Debug.Log(name + " Caused damaged " + damage);
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.Damage(damage);
            }
        }
    }
    
	// puts attacker into attack mode
    public void Attack(GameObject obj){
        currentTarget = obj;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.name + " Trigger Enter");  
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
