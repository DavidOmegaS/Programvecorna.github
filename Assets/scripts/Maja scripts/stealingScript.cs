using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealingScript : interactableObject
{
    public GameObject item;
    stolenPointSystem sps;
    public int itemsStolen = 0;
    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E) && gameObject.tag == "item")
        {
            item.SetActive(false);
            itemsStolen++;
            print("item stolen");
            
            
            /*if (gameObject.layer == 10)
            {
                sps.appleScore+= 1;
            }

            if(gameObject.layer == 11)
            {
                sps.watermelonScore+= 1;
            }*/
        }
        
    }
}
