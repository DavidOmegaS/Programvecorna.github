using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    itemCollector itemScript;
    public GameObject victoryScreen;

    void Start()
    {
        
    }

    void Update()
    {
        if (itemScript.itemsTotal == 12)
        {
            Debug.Log("Victory!!");
        }
    }
}
