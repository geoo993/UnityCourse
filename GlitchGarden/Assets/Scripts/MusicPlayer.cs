using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    public AudioClip startClip = null;
    public AudioClip gameClip = null;
    public AudioClip endClip = null;

    private AudioSource music;
    
    // Use this for initialization
    void Awake () {
        if (instance != null){
            Destroy(gameObject);
            //Debug.Log("Duplicate MusicPlayer self-destructed");
        }else{
            instance = this;
			DontDestroyOnLoad(gameObject);

            music = this.GetComponent<AudioSource>();
            PlayMusic(startClip);
        }
    }
    
    void PlayMusic( AudioClip clip){

        if (music)
        {
            music.Stop();
            music.clip = clip;
            music.loop = true;
            music.Play();
        }
    }
    
    void OnLevelWasLoaded(int level)
    {

        if (level < 6 && level > 1)
        {
       
        } else if (level == 0){
            PlayMusic(startClip); //// start menu
        } else if (level == 1){ 
            PlayMusic(gameClip);  //// first game level
        }else if (level == 6 || level == 7){
            PlayMusic(endClip);   //// end of game
        }
        
        
    }

}
