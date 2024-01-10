using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{//ossian. Script för gameoverscreen och victory.

    
    bool playerWin;
    bool PlayerCaught;
    [SerializeField]
    GameObject Gameoverscreen;
    [SerializeField]
    GameObject Victoryscreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //om spelaren vinner ska gameover visas
                                         //Sen kan kanske en bild på att spelaren delar ut maten visas efter en tid
        {

            Victoryscreen.SetActive(!Victoryscreen.activeSelf);

        }
        if (Input.GetKeyDown(KeyCode.Escape))//om spelaren dör (blir fångad) ska gameovertexten visas
        {

            Gameoverscreen.SetActive(!Gameoverscreen.activeSelf);


            {

                /*-----------------------------------------------------------------------------------*/
                /*-----------------------------------------------------------------------------------*/
                /*-----------------------------------------------------------------------------------*/

            }





        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadScene();
        }
    }

    public void reloadScene()

    {
        print("reloading scene");
        SceneManager.LoadScene(2);

    }


}







