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
        ChangeAlpha(player.GetComponent<Renderer>().material, otherAlpha);
    }

    private void Update()
    {
        if(canHide == true)
        {
            if ( (Input.GetKey(KeyCode.E)))
            {
                player.transform.position = transform.position;
                ChangeAlpha(player.GetComponent<Renderer>().material, alpha);
            }

        }
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        print(alphaVal);
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}