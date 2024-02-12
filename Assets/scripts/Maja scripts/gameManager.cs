using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    

    public void Play()
    {
        SceneManager.LoadScene("mainScene"); //när den här voiden händer, t.ex. när man trycker på en knapp, så loadar den scenen som heter mainScene
    }

    public void Quit() //spelet stängs ner
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void restart()
    {
        SceneManager.LoadScene("mainScene");
        Time.timeScale = 1;
    }
}
