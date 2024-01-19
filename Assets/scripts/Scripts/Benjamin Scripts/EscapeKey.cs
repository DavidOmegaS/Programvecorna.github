using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EscapeKey : MonoBehaviour
{
    public bool IsPaused;
    [SerializeField] Canvas pausemenu;

    void Start()
    {
        Time.timeScale = 1;
        IsPaused = false;
        pausemenu.GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && IsPaused == false)
        {
            pausemenu.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            IsPaused = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == true)
        {
            pausemenu.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
            IsPaused = false;

        }

    }

    //gjorde en resume button - Maja
    public void resume()
    {
        pausemenu.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        IsPaused = false;
    }
}
