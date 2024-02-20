using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{

    // these are the music loops and clips used for specific reasons
    [SerializeField] AudioSource Step;
    [SerializeField] AudioSource AmbientMusic;
    [SerializeField] AudioSource StressMusic;
    [SerializeField] AudioSource MenuTheme;
    [SerializeField] newPlayerMovement nPL;

    [SerializeField] GameObject victoryscreen; 

    public bool Stress;

    public AudioClip[] clips;
    [SerializeField] float loopdelay;
    bool CanPlay;

    // for determing which audiosource its using

    [SerializeField] bool IsmenuScene;
    
    void Start()
    {
        CanPlay = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (IsmenuScene == false)
        {
            if (nPL.IsWalking == true && CanPlay == true) // if player is walking play step sounds
            {
                StartCoroutine(AudioDelay());
            }

            if (Stress == true && !StressMusic.isPlaying) // play chase music if guards see you (currently game stops before that happens)
            {
                AmbientMusic.Pause();
                StressMusic.UnPause();
                StressMusic.Play();

            }
            else if (Stress == false && !AmbientMusic.isPlaying) // Ambient music plays if nothing is happening
            {
                StressMusic.Pause();
                AmbientMusic.UnPause();
                AmbientMusic.Play();
            }
        }

        if (IsmenuScene == true && !MenuTheme.isPlaying) // if currentscene is menuscene then play music
        {
            MenuTheme.Play();
        }
        else if (victoryscreen.activeSelf == true && !MenuTheme.isPlaying) // for playing a music loop if victory screen object is true
        {
            StressMusic.Pause();
            AmbientMusic.Pause();
            MenuTheme.Play();
        }
    }

    IEnumerator AudioDelay() // Delays a clip a specific amount so it doesnt play on top of eachother
    {
        CanPlay = false;
        print("steps");
        Step.Play();
        yield return new WaitForSeconds(loopdelay);
        CanPlay = true;
        StopCoroutine(AudioDelay());
    }
}
