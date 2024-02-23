using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingScript : MonoBehaviour
{
    public GameObject player;
    public float alpha = 0f;  //player alpha, 0 alpha gör så att playern blir osynlig/igenomskinlig men finns fortfarande i spelet
    public float otherAlpha = 1f; //player är synlig igen
    private bool canHide; //kan gömma sig
    public bool isHiding; //gömmer sig

    private void OnTriggerEnter2D(Collider2D other)
    {
        canHide = true;//när man collidear så kan man gömma sig
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canHide = false; //när man inte collidear så kan man inte gömma sig
        ChangeAlpha(player.GetComponent<Renderer>().material, otherAlpha); //man syns
    }

    private void Update()
    {
        if(canHide == true) //om man kan gömma sig så och:
        {
            if ((Input.GetKey(KeyCode.E))) //trycker på E så:
            {
                player.transform.position = transform.position; //ens position blir samma som objektet man gömmer sig i
                ChangeAlpha(player.GetComponent<Renderer>().material, alpha);//osynlig!!!
                isHiding = true;//gömmer sig :)
            }

        }
    }

    void ChangeAlpha(Material mat, float alphaVal)//ändrar ens alpha value wowowow osynlig eller synlig no way
    {
        print(alphaVal);
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal); //färgerna är fortfarande normala, men alphan ändras
        mat.SetColor("_Color", newColor);
    }
}