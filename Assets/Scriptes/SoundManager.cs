using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour

{

    // Strings, die man übergeben kann zum abspielen: | kotzen | essen | hello | helicopter | wal | win |



    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource bg_musicSource;                 //Drag a reference to the audio source which will play the music.
    public AudioSource windSource;                  
    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
    public AudioClip essen1;
    public AudioClip essen2;
    public AudioClip essen3;
    public AudioClip kotzen;
    public AudioClip hello;
    public AudioClip helicopter;
    public AudioClip wal;
    public AudioClip win1;
    public AudioClip win2;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    //Used to play single sound clips.
    public void PlaySingle(string effectName)
    {
        if (effectName.Equals("kotzen"))
        {
            efxSource.clip = kotzen;
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            efxSource.pitch = randomPitch;
            efxSource.Play();
        }
        else if (effectName.Equals("essen"))
        {
            RandomizeSfx(essen1, essen2, essen3);
        }
        else if (effectName.Equals("hello"))
        {
            efxSource.clip = hello;
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            efxSource.pitch = randomPitch;
            efxSource.Play();
        }
        else if (effectName.Equals("helicopter"))
        {
            efxSource.clip = helicopter;
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            efxSource.pitch = randomPitch;
            efxSource.Play();
        }
        else if (effectName.Equals("wal"))
        {
            efxSource.clip = wal;
                        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            efxSource.pitch = randomPitch;
            efxSource.Play();
        }
        else if (effectName.Equals("win"))
        {
            efxSource.clip = win1;
            efxSource.Play();
            efxSource.clip = win2;
            efxSource.Play();
        }
        
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;

        efxSource.clip = clips[randomIndex];

        efxSource.Play();
    }
}