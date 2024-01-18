using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemCollector : MonoBehaviour
{
    public int apples = 0;
    TextMeshProUGUI tmp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            Destroy(collision.gameObject);
            apples++;
            Debug.Log("Apples: " + apples);
        }
    }
}
