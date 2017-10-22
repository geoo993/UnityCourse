using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float padding = 0.5f;
    public float playerSpeed = 5.0f;
    public float playerHealth = 100.0f;
    public GameObject playerProjectile;
	public float projectileSpeed = 1.0f;
    [Range(0.0f, 20.0f)] public float projectileFiringRate = 5.0f;
    public AudioClip fireSound;
    
    private float xMin;// = 0.5f;
    private float xMax;// = 15.5f;
    
	// Use this for initialization
	void Start () {
    
        ////// calculate screen edges
        // distance between camera and player
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        
        // relative distance on left of the camera in x is 0.0f which gets the minimum width or left most value
        Vector3 leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, distance));
        
        // relative distance on right of the camera in x is 1.0f which gets the maximum width or right most value
        Vector3 rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, distance));

        float halfLocalScaleX = padding;//this.transform.localScale.x * 0.5f;
        xMin = leftMostPosition.x + halfLocalScaleX;
        xMax = rightMostPosition.x - halfLocalScaleX;
	}
	
	// Update is called once per frame
	void Update () {

        MovePlayerGeneric();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, projectileFiringRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
	}
    
    void Fire(){
        Vector3 projectilePosition = this.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        GameObject projectile = Instantiate(playerProjectile, projectilePosition, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, this.transform.position);
    }
    
    void MovePlayerGeneric(){
        Vector3 position = this.transform.position;
        
        if(Input.GetKey(KeyCode.LeftArrow)){
            position += Vector3.left * projectileSpeed * Time.deltaTime; 
        }
        
        if(Input.GetKey(KeyCode.RightArrow)){
            position += Vector3.right * projectileSpeed * Time.deltaTime; 
        }
        
        // restrict player game space
        position.x = Mathf.Clamp(position.x, xMin, xMax);
        
        this.transform.position = position;
    }
    
    void MovePlayer(){
        Vector3 position = this.transform.position;
        
        if(Input.GetKey(KeyCode.LeftArrow)){
            position.x -= projectileSpeed * Time.deltaTime; 
        }
        
        if(Input.GetKey(KeyCode.RightArrow)){
            position.x += projectileSpeed * Time.deltaTime; 
        }
        position.x = Mathf.Clamp(position.x, xMin, xMax);
        
        this.transform.position = position;
    }

    void PlayerHit(float damage){
        playerHealth -= damage;
        
        //print("Hit something, health is " +playerHealth);
        if (playerHealth <= 0.0f) { Die(); }
    }
    
    void Die(){
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose");
        Destroy(gameObject);
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyProjectile projectile = collision.gameObject.GetComponent<EnemyProjectile>();

        if (projectile != null){
			
			projectile.Hit();
            PlayerHit(projectile.GetDamage());
        }
    }
}
