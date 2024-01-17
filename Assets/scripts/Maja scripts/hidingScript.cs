using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingScript : interactableObject
{
    public GameObject player;
    public GameObject beforeHiding;
    public GameObject afterHiding;
    public GameObject leaveText;
    public GameObject hideText;

    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E) && gameObject.tag == "hideout")
        {
            OnInteract();
            player.transform.position = new Vector2(5f, 1f);
            beforeHiding.SetActive(false);
            afterHiding.SetActive(true);
            leaveText.SetActive(true);
            hideText.SetActive(false);
        }

    }

}