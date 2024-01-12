using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingScript : interactableObject
{
    private int hej;
    public GameObject hideout;
    public GameObject hideButton;

    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E) && gameObject.tag == "hideout")
        {
            OnInteract();            
        }
        hideButton.SetActive(true);
    }

}
