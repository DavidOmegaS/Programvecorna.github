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
    public EnemySight sight;
    public timer time;


    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;//den activa scenens namn
        sight = GetComponent<EnemySight>();

        Time.timeScale = 1; // Startar spelet -David
    }
    void Update()
    {

        
       /* if ( loseScreenOn == false) //om spelaren vinner ska gameover visas
                                         //Sen kan kanske en bild på att spelaren delar ut maten visas efter en tid
        {

            Victoryscreen.SetActive(true);
            winScreenOn = true;
        }*/
        if (sight.CurrentlyInSight == true && winScreenOn == false || time.timeIsUp == true)//om spelaren dör (blir fångad) ska gameovertexten visas
        {

            Gameoverscreen.SetActive(true);
            loseScreenOn = true;
            Time.timeScale = 0; // Stoppar spelet -David

           

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
        Time.timeScale = 1; //-David

    }


}







