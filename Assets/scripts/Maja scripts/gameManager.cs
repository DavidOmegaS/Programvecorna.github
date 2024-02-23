using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //s� att jag kan anv�nda scene koder

public class gameManager : MonoBehaviour
{
    

    public void Play() //n�r den h�r voiden h�nder, t.ex. n�r man trycker p� en knapp, s� loadar den scenen som heter mainScene
    {
        SceneManager.LoadScene("mainScene");
    }

    public void Quit() //spelet st�ngs ner
    {
        Application.Quit();
        Debug.Log("Player quit"); //says if the void works since we can't see if it works otherwise if we are not in a build
    }

    public void mainMenu() //byter till scenen mainMenu
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void restart() //reloadar scenen mainScene vilket startar om allt och timeScale g�r s� att spelet inte �r fryst/pausat
    {
        SceneManager.LoadScene("mainScene");
        Time.timeScale = 1;
    }
}
