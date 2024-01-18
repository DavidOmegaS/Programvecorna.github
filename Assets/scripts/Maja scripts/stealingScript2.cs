using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealingScript2 : MonoBehaviour
{
    private bool canSteal;
    public int itemsStolen = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        canSteal = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canSteal = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(canSteal == true)
        {
            if (Input.GetKey(KeyCode.E) && gameObject.tag == "item")
            {
                gameObject.SetActive(false);
                itemsStolen++;
                print("item stolen");
            }
        }
    }
}
