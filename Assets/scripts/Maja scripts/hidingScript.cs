using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingScript : interactableObject
{
    public GameObject player;

    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E) && gameObject.tag == "hideout")
        {
            OnInteract();
            player.transform.position = new Vector2(5f, 1f);
            player.SetActive(false);
            
        }
    }
}