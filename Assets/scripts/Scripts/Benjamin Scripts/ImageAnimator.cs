using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnimator : MonoBehaviour
{
    [SerializeField] bool VictoryScreen;
    [SerializeField] bool GameOverScreen;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
