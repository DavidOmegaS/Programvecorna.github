using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detect : MonoBehaviour
{
    public EnemySight sight;
    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        sight = GetComponent<EnemySight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sight.CurrentlyInSight == true)
        {
            test = true;
        }
        else
        {
            test = false;
        }
    }
}
