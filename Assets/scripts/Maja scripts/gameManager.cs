using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    

    public void Play()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("player quit");
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
