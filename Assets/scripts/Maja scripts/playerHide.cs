using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHide : hidingScript
{
    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E) && gameObject.tag == "hideout")
        {
            
        }

    }
}
