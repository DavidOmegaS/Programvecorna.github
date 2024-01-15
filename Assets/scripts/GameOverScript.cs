using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{//ossian. Script för gameoverscreen och victory.
    string currentSceneName;
    public bool winScreenOn;
    public bool loseScreenOn;
    bool playerWin;
    bool PlayerCaught;
    [SerializeField]
    GameObject Gameoverscreen;
    [SerializeField]
    GameObject Victoryscreen;

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;//den activa scenens namn
    }
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.W) && loseScreenOn == false) //om spelaren vinner ska gameover visas
                                         //Sen kan kanske en bild på att spelaren delar ut maten visas efter en tid
        {

            Victoryscreen.SetActive(!Victoryscreen.activeSelf);
            winScreenOn = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && winScreenOn == false)//om spelaren dör (blir fångad) ska gameovertexten visas
        {

            Gameoverscreen.SetActive(!Gameoverscreen.activeSelf);
            loseScreenOn = true;

            {

                /*-----------------------------------------------------------------------------------*/
                /*-----------------------------------------------------------------------------------*/
                /*-----------------------------------------------------------------------------------*/

            }

        }

        if (Input.GetKeyDown(KeyCode.R))//reloadar scenen
        {
            reloadScene();
        }

        if (Gameoverscreen.activeSelf==false)//om win/lose skärmen visas kan man inte visa den andra
        {                                    //kan byta denna mot typ settings så att man inte kan se settings och vanliga menyn samtidigt.
            loseScreenOn = false;
        }
        if (Victoryscreen.activeSelf == false)
        {
           winScreenOn = false;
        }
    }

    public void reloadScene()

    {
        print("reloading scene");
        SceneManager.LoadScene(currentSceneName);//laddar om den aktuella scenen

    }


}







