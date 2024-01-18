using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject[] cutscenes;
    int currentcutscene;
    bool On;
    // Start is called before the first frame update
    void Start()
    {
        On = false;
        currentcutscene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(On == true) 
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Backspace))
            {
                cutscenes[currentcutscene].SetActive(false);
                currentcutscene += 1;
                cutscenes[currentcutscene].SetActive(true);

            }

            if (currentcutscene >= 3)
            {
                SceneManager.LoadScene("mainScene");
            }
        }

    }

    public void PlayCutscenes()
    {

        cutscenes[currentcutscene].SetActive(true);
        menu.SetActive(false);
        On = true;

    }
}
