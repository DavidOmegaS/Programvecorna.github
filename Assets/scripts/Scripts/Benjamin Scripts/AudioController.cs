using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
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
            if (nPL.IsWalking == true && CanPlay == true)
            {
                StartCoroutine(AudioDelay());
            }

            if (Stress == true && !StressMusic.isPlaying)
            {
                AmbientMusic.Pause();
                StressMusic.UnPause();
                StressMusic.Play();

            }
            else if (Stress == false && !AmbientMusic.isPlaying)
            {
                StressMusic.Pause();
                AmbientMusic.UnPause();
                AmbientMusic.Play();
            }
        }

        if (IsmenuScene == true && !MenuTheme.isPlaying)
        {
            MenuTheme.Play();
        }
        else if (victoryscreen == true && !MenuTheme.isPlaying) 
        {
            StressMusic.Pause();
            AmbientMusic.Pause();
            MenuTheme.Play();
        }
    }

    IEnumerator AudioDelay()
    {
        CanPlay = false;
        print("steps");
        Step.Play();
        yield return new WaitForSeconds(loopdelay);
        CanPlay = true;
        StopCoroutine(AudioDelay());
    }
}
