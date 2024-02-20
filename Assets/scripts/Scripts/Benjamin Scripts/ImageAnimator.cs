using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnimator : MonoBehaviour
{
    [SerializeField] bool VictoryScreen; // bools for specific animations in the Image animator (makes sure it doesnt turn on the wrong animation)
    [SerializeField] bool GameOverScreen;
    Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // objects animator
    } 

    void Update() // if bool true let animator play specific animation
    {
        if(VictoryScreen == true) 
        {
            animator.SetBool("victoryscreen", true);
        }

        if (GameOverScreen == true)
        {
            animator.SetBool("gameoverscreen", true);
        }
    }
}
