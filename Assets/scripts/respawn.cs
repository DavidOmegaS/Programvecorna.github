using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            SceneManager.LoadScene("mainScene");
            Debug.Log("hej hej");
        }
    }
}