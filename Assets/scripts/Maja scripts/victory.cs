using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    itemCollector itemScript;
    private bool winner;

    void Start()
    {
        
    }

    void Update()
    {
        if (itemScript.itemsTotal == 12)
        {
            winner = true;
        }
    }
}
