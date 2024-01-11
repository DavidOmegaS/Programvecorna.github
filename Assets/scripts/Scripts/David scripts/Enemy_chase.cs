using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chase : MonoBehaviour
{
    public EnemySight sight;
    // Start is called before the first frame update
    void Start()
    {
        sight = GetComponent<EnemySight>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
