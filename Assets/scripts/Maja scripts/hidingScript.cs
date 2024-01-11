using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingScript : MonoBehaviour, IInteractable
{
    bool hiding = false;
    public GameObject E;
    public void Interact()
    {
        Debug.Log("interacted");
        hiding = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
