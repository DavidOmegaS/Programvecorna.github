using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource Step;
    [SerializeField] AudioSource AmbientMusic;
    [SerializeField] AudioSource StressMusic;
    [SerializeField] newPlayerMovement nPL;

    public bool Stress;

    public AudioClip[] clips;
    [SerializeField] float loopdelay;
    bool CanPlay;

    // for determing which audiosource its using

    [SerializeField] bool Player;
    [SerializeField] bool Enemy;
    [SerializeField] bool Environmental;
    
    void Start()
    {
        CanPlay = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (nPL.IsWalking == true && CanPlay == true) 
        {
            StartCoroutine(AudioDelay());
        }

        if (Stress == true && !StressMusic.isPlaying)
        {
            StressMusic.Play();
            
        }
        else if(Stress == false && !AmbientMusic.isPlaying)
        {
            AmbientMusic.Play();
        }

    }

    IEnumerator AudioDelay()
    {
        CanPlay = false;
        Step.Play();
        yield return new WaitForSeconds(loopdelay);
        CanPlay = true;
        StopCoroutine(AudioDelay());
    }
}
