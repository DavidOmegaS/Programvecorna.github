using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    stealingScript ss;
    stealingScript2 ss2;
    public GameObject victoryScreen;

    void Start()
    {
        
    }

    void Update()
    {
        if(ss.itemsStolen == 1)
        {
            victoryScreen.SetActive(true);
        }
    }
}
