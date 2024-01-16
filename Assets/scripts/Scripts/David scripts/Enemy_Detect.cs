using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Detect : MonoBehaviour
{
    public EnemySight sight;
    public bool test;
    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        sight = GetComponent<EnemySight>();
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (sight.CurrentlyInSight == true)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
       
       
    }
}
