using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    

    public void Play()
    {
        SceneManager.LoadScene("mainScene"); //n�r den h�r voiden h�nder, t.ex. n�r man trycker p� en knapp, s� loadar den scenen som heter mainScene
    }

    public void Quit() //spelet st�ngs ner
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
