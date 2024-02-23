using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingScript : MonoBehaviour
{
    public GameObject player;
    public float alpha = 0f;  //player alpha, 0 alpha g�r s� att playern blir osynlig/igenomskinlig men finns fortfarande i spelet
    public float otherAlpha = 1f; //player �r synlig igen
    private bool canHide; //kan g�mma sig
    public bool isHiding; //g�mmer sig

    private void OnTriggerEnter2D(Collider2D other)
    {
        canHide = true;//n�r man collidear s� kan man g�mma sig
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canHide = false; //n�r man inte collidear s� kan man inte g�mma sig
        ChangeAlpha(player.GetComponent<Renderer>().material, otherAlpha); //man syns
    }

    private void Update()
    {
        if(canHide == true) //om man kan g�mma sig s� och:
        {
            if ((Input.GetKey(KeyCode.E))) //trycker p� E s�:
            {
                player.transform.position = transform.position; //ens position blir samma som objektet man g�mmer sig i
                ChangeAlpha(player.GetComponent<Renderer>().material, alpha);//osynlig!!!
                isHiding = true;//g�mmer sig :)
            }

        }
    }

    void ChangeAlpha(Material mat, float alphaVal)//�ndrar ens alpha value wowowow osynlig eller synlig no way
    {
        print(alphaVal);
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal); //f�rgerna �r fortfarande normala, men alphan �ndras
        mat.SetColor("_Color", newColor);
    }
}