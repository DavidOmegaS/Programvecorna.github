using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingScript : MonoBehaviour
{
    public GameObject player;
    public float alpha = 0f;
    public float otherAlpha = 1f;
    private bool canHide;

    private void OnTriggerEnter2D(Collider2D other)
    {
        canHide = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canHide = false;
    }

    private void Update()
    {
        if(canHide == true)
        {
            if (gameObject.name.Equals("tunna") && (Input.GetKey(KeyCode.E)))
            {
                player.transform.position = new Vector2(5f, 1f);
                ChangeAlpha(player.GetComponent<Renderer>().material, alpha);
            }
            
            if (gameObject.name.Equals("hayball") && (Input.GetKey(KeyCode.E)))
            {
                player.transform.position = new Vector2(2.5f, 0.7f);
                ChangeAlpha(player.GetComponent<Renderer>().material, alpha);
            }

        }
        else
        {
            if (gameObject.name.Equals("tunna"))
            {
                ChangeAlpha(player.GetComponent<Renderer>().material, otherAlpha);
            }

        }
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}