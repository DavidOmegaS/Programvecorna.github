using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : collision
{
    private bool interacted = false;

    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
    }
    public void OnInteract()
    {
        if (interacted == false)
        {
            interacted = true;
            Debug.Log("Interacted with " + name);
        }
    }
}
