using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealingScript : interactableObject
{
    public GameObject item;
    public GameObject stealButton;
    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E) && gameObject.tag == "item")
        {
            OnInteract();
            item.SetActive(false);
        }
        stealButton.SetActive(true);
    }
}
