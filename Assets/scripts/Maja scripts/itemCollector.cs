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
            itemsText.text = "- Apples " + apples + "/4            - Watermelons " + watermelons + "/4 - Coin bags " + coins + "/5";
            
        }

        if (collision.gameObject.CompareTag("watermelon"))
        {
            Instantiate(prefabster, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            watermelons++;
            itemsTotal++;
            itemsText.text = "- Apples " + apples + "/4            - Watermelons " + watermelons + "/4 - Coin bags " + coins + "/5";
            
        }

        if (collision.gameObject.CompareTag("coins"))
        {
            Instantiate(prefabster, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            coins++;
            itemsTotal++;
            itemsText.text = "- Apples " + apples + "/4            - Watermelons " + watermelons + "/4 - Coin bags " + coins + "/5";
           
        }

        if (collision.gameObject.CompareTag("exit") && itemsTotal == 13)
        {
            Debug.Log("Victory!!");
            victoryScreen.SetActive(true);
            stealList.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            victoryScreen.SetActive(false);
            stealList.SetActive(true);
        }
    }
}
