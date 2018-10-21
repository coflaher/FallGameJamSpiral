using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    // Audio player components.
    public AudioSource musicSource;
    public AudioSource efxSource;

    //Singleton Instance.
    public static SoundManager instance = null;

    // Random pitch adjustment range.
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;
	
    // Initialize the singleton instance.
	void Awake ()
    {
        // If there is not an instance of SoundManager, set it to this.
        if (instance == null)
        {
            instance = this;
        } 
        // If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
		
	}
	
    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.PlayOneShot(clip);
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    //Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
    }



    

}
