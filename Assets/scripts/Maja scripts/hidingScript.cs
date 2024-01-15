using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingScript : interactableObject
{
    private int hej;
    public GameObject player;
    public GameObject E;
    private bool AAA = false;

    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E) && gameObject.tag == "hideout")
        {
            OnInteract();
            player.transform.position = new Vector2(0, 0);
        }
        AAA = true;
        
        if(AAA == true)
        {
            E.SetActive(true);
        }
        else
        {
            E.SetActive(false);
        }

    }

}