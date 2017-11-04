using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Range(10, 540)]
    public float levelSeconds = 270;

    private GameObject winLabel;
    private LevelManager levelManager;
    private Slider gameSlider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    
	// Use this for initialization
	void Start ()
    {
        gameSlider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        FindWinLabelText();
        winLabel.SetActive(false);
    }

    private void FindWinLabelText()
    {
        winLabel = GameObject.Find("levelCompletedText");

        if (winLabel == null)
        {
            Debug.LogWarning("Please create levelCompletedText object");
        }
    }

    // Update is called once per frame
    void Update () {
    
        float progress = ((Time.timeSinceLevelLoad) / levelSeconds) * 100.0f;
        gameSlider.value = progress;

        if (Time.timeSinceLevelLoad > levelSeconds && isEndOfLevel == false)
        {
            HandleWinCondition();
        }

    }

    void HandleWinCondition()
    {
        DestroyObjectsOnWin();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void DestroyObjectsOnWin()
    {
        DestroyObjectsWith("Defenders");
        DestroyObjectsWith("Attackers");
        DestroyObjectsWith("Projectiles");
    }

    void DestroyObjectsWith(string objTag){
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objTag);
        foreach (GameObject obj in objs){
            Destroy(obj);
        }
    }
    
    void LoadNextLevel(){
        levelManager.LoadNextLevel();
    }
    
    
}
