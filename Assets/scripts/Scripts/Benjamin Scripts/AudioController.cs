using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource AS;
    [SerializeField] newPlayerMovement nPL;
    public AudioClip[] clips;
    [SerializeField] float loopdelay;
    bool CanPlay;
    float dashtimer;

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

      if (nPL.IsDashing = true && dashtimer >= 1.5f)
      {
            AS.PlayOneShot(clips[3])
            dashtimer = Time.deltaTime;
      }
    
    }

    IEnumerator AudioDelay()
    {
        CanPlay = false;
        AS.Play();
        yield return new WaitForSeconds(loopdelay);
        CanPlay = true;
        StopCoroutine(AudioDelay());
    }
}
