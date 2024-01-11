using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : collision
{
    protected bool interacted = false;

    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
    }
    private void OnInteract()
    {
        Debug.Log("Interacted with " + name);
        interacted = true;
    }
}
