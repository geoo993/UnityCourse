using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public GameObject enemyProjectile;
	public float projectileSpeed = 5.0f;
    public int scoreValue = 150;
    public AudioClip fireSound;
    public AudioClip deathSound;
    
    [SerializeField, Range(0.0f, 2.0f)] 
    private float shootsPerSecond = 0.2f; // frequency of fire
    
    [SerializeField, Range(50.0f, 200.0f)] 
    private float health = 100.0f;

    private ScoreKeeper scoreKeeper;
    
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    void Update()
    {
    
        // turning probabilty into a decision
        float probability = Time.deltaTime * shootsPerSecond;

        if (Random.value < probability)
        {
            Fire();
        }
    }
    
    void Fire(){
        
        Vector3 projectilePosition = this.transform.position + new Vector3(0.0f, -0.5f, 0.0f);
        GameObject projectile = Instantiate(enemyProjectile, projectilePosition, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, this.transform.position);
    }
    
    void Hit(float damage){
		health -= damage;
		
		//print("hit projectile and health is "+ health);
        if (health <= 0.0f) { 
            Die();
        }
    }
    
    void Die(){
        AudioSource.PlayClipAtPoint(deathSound, this.transform.position);
        scoreKeeper.Score(scoreValue);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerProjectile projectile = collision.gameObject.GetComponent<PlayerProjectile>();

        if (projectile != null){
			projectile.Hit();
            Hit(projectile.GetDamage());
        }
        
    }
}
