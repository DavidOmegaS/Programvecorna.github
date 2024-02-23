using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //så att jag kan använda scene koder

public class gameManager : MonoBehaviour
{
    

    public void Play() //när den här voiden händer, t.ex. när man trycker på en knapp, så loadar den scenen som heter mainScene
    {
        SceneManager.LoadScene("mainScene");
    }

    public void Quit() //spelet stängs ner
    {
        Application.Quit();
        Debug.Log("Player quit"); //says if the void works since we can't see if it works otherwise if we are not in a build
    }

    public void mainMenu() //byter till scenen mainMenu
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void restart() //reloadar scenen mainScene vilket startar om allt och timeScale gör så att spelet inte är fryst/pausat
    {
        SceneManager.LoadScene("mainScene");
        Time.timeScale = 1;
    }
}
