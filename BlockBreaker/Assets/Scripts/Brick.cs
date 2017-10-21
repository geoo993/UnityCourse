using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public int maxHits;
    public Sprite[] hitSprites;
    public GameObject smoke;

    public static int breakableBrickCount = 0;
    
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable = false;
    
    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Use this for initialization
    void Start () {
		isBreakable = (this.tag == "Breakable");
        // keep track of breakable bricks
        if (isBreakable){
            breakableBrickCount++;
        }
        timesHit = 0;
	}

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit += 1;
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
		this.GetComponent<AudioSource>().PlayOneShot(crack, 0.7f);
        if (isBreakable) {
            HandleCollision();
        }
    }
    
    void HandleCollision(){
		if (timesHit >= maxHits)
		{
            breakableBrickCount--;
            levelManager.BrickDestroyed();
            GenerateSmoke();
            Destroy(gameObject);
        }else{
            LoadSprites();
        }
    }
    
    void GenerateSmoke(){
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position,Quaternion.identity);
       
        ParticleSystem.MainModule mainSystem = smokePuff.GetComponent<ParticleSystem>().main;
        mainSystem.startColor = new ParticleSystem.MinMaxGradient( color );
    }
    
    void LoadSprites(){

        int spriteIndex = timesHit - 2;

        if (spriteIndex >= 0 && spriteIndex < hitSprites.Length ){
            if (hitSprites[spriteIndex] == null){
                Debug.LogError("Error: no brick sprite available");
                return;
            }
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    
    }
    
    
}
