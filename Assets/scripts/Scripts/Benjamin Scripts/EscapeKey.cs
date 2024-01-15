using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EscapeKey : MonoBehaviour
{
    GameOverScript GOS;
    public bool IsPaused;
    [SerializeField] Canvas pausemenu;

    void Start()
    {
        Time.timeScale = 1;
        IsPaused = false;
        GOS = GetComponent<GameOverScript>();
        pausemenu.GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && IsPaused == false && (GOS.winScreenOn == false || GOS.loseScreenOn == false))
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

    public void MonoQuit() // made a duplicate quit void function since textmashpro apperantly cant detect InteracteObject scripts? Unsure
    {
        Application.Quit();
    }

    public void MonoMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
