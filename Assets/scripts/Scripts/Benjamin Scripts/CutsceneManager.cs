using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject[] cutscenes;
    int currentcutscene;
    bool On; // is script on or off?
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
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Backspace)) // press any of these buttons and it goes to the next cutscene and disables current cutscene image.
            {
                cutscenes[currentcutscene].SetActive(false);
                currentcutscene += 1;
                cutscenes[currentcutscene].SetActive(true);

            }

            if (currentcutscene >= 3) // if currentcutscene is 3 or higher go to main scene
            {
                SceneManager.LoadScene("mainScene");
            }
        }

    }

    public void PlayCutscenes() // Void used with textmashpro buttons to activate cutscene images
    {

        cutscenes[currentcutscene].SetActive(true); 
        menu.SetActive(false);
        On = true;

    }
}
