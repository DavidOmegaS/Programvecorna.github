using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chase : MonoBehaviour
{
    public EnemySight sight;
    public bool test;
    // Start is called before the first frame update
    void Start()
    {
        sight = GetComponentInChildren<EnemySight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sight.IsChasing == true)
        {
            test = true;
        }
        else
        {
            test = false;
        }
        
    }
}
