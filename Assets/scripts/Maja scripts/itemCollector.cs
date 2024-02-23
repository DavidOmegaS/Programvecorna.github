using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemCollector : MonoBehaviour
{
    public GameObject prefabster; //confetti
    //object som man kan stj�la, och hur m�nga man har stulit
    private int apples = 0;
    private int watermelons = 0;
    private int coins = 0;
    public int itemsTotal = 0;
    //ui
    public GameObject victoryScreen;
    public GameObject stealList;

    [SerializeField] 
    private TextMeshProUGUI itemsText;//texten p� sk�rmen som visar hur mycket du har stulit




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))//om man g�r i ett �pple s�:
        {
            Instantiate(prefabster, transform.position, Quaternion.identity);//confetti
            Destroy(collision.gameObject);//�pple f�rsvinner
            apples++;//�pple amount blir +1
            itemsTotal++;//items totalt blir +1
            itemsText.text = "- Apples " + apples + "/4            - Watermelons " + watermelons + "/4 - Coin bags " + coins + "/5"; //texten p� sk�rmen �ndras baserat p� hur mycket av grejerna du har stulit
            
        }

        if (collision.gameObject.CompareTag("watermelon"))//samma sak som �pple fast det h�nder om man g�r in i en vattenmelon
        {
            Instantiate(prefabster, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            watermelons++;
            itemsTotal++;
            itemsText.text = "- Apples " + apples + "/4            - Watermelons " + watermelons + "/4 - Coin bags " + coins + "/5";
            
        }

        if (collision.gameObject.CompareTag("coins")) //samma sak som �pple och vattenmelon men det h�nder om man g�r in i en coin bag
        {
            Instantiate(prefabster, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            coins++;
            itemsTotal++;
            itemsText.text = "- Apples " + apples + "/4            - Watermelons " + watermelons + "/4 - Coin bags " + coins + "/5";
           
        }

        if (collision.gameObject.CompareTag("exit") && itemsTotal == 13) //om man har stulit allting och man g�r in i exit s� vinner man yipee
        {
            Debug.Log("Victory!!");
            victoryScreen.SetActive(true);//victory screen syns
            stealList.SetActive(false); //steal list syns inte
            Time.timeScale = 0; //allting pausas s� man inte kan r�ra p� sig o s�nt
        }
        else //om man inte har vunnit s�:
        {
            victoryScreen.SetActive(false); //victory syns inte
            stealList.SetActive(true); //steal list syns
        }
    }
}
