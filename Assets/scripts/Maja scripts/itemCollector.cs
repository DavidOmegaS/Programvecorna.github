using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemCollector : MonoBehaviour
{
    public GameObject prefabster;
    private int apples = 0;
    private int watermelons = 0;
    private int coins = 0;
    public int itemsTotal = 0;
    public GameObject victoryScreen;

    [SerializeField] 
    private TextMeshProUGUI itemsText;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Instantiate(prefabster, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            apples++;
            itemsTotal++;
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
            Time.timeScale = 0;
        }
        else
        {
            victoryScreen.SetActive(false);
        }
    }
}
