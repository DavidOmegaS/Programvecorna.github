using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemCollector : MonoBehaviour
{
    public GameObject prefabster; //confetti
    //object som man kan stjäla, och hur många man har stulit
    private int apples = 0;
    private int watermelons = 0;
    private int coins = 0;
    public int itemsTotal = 0;
    //ui
    public GameObject victoryScreen;
    public GameObject stealList;

    [SerializeField] 
    private TextMeshProUGUI itemsText;//texten på skärmen som visar hur mycket du har stulit




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))//om man går i ett äpple så:
        {
            Instantiate(prefabster, transform.position, Quaternion.identity);//confetti
            Destroy(collision.gameObject);//äpple försvinner
            apples++;//äpple amount blir +1
            itemsTotal++;//items totalt blir +1
            itemsText.text = "- Apples " + apples + "/4            - Watermelons " + watermelons + "/4 - Coin bags " + coins + "/5"; //texten på skärmen ändras baserat på hur mycket av grejerna du har stulit
            
        }

        if (collision.gameObject.CompareTag("watermelon"))//samma sak som äpple fast det händer om man går in i en vattenmelon
        {
            Instantiate(prefabster, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            watermelons++;
            itemsTotal++;
            itemsText.text = "- Apples " + apples + "/4            - Watermelons " + watermelons + "/4 - Coin bags " + coins + "/5";
            
        }

        if (collision.gameObject.CompareTag("coins")) //samma sak som äpple och vattenmelon men det händer om man går in i en coin bag
        {
            Instantiate(prefabster, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            coins++;
            itemsTotal++;
            itemsText.text = "- Apples " + apples + "/4            - Watermelons " + watermelons + "/4 - Coin bags " + coins + "/5";
           
        }

        if (collision.gameObject.CompareTag("exit") && itemsTotal == 13) //om man har stulit allting och man går in i exit så vinner man yipee
        {
            Debug.Log("Victory!!");
            victoryScreen.SetActive(true);//victory screen syns
            stealList.SetActive(false); //steal list syns inte
            Time.timeScale = 0; //allting pausas så man inte kan röra på sig o sånt
        }
        else //om man inte har vunnit så:
        {
            victoryScreen.SetActive(false); //victory syns inte
            stealList.SetActive(true); //steal list syns
        }
    }
}
