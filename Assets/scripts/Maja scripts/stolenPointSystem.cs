using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class stolenPointSystem : MonoBehaviour
{
    public TextMeshProUGUI score;

    public int appleScore = 0;
    public int watermelonScore = 0;
    public  int coinScore = 0;

    void Start()
    {
        //score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score.text = "- Apple " + appleScore + "/3            - Watermelon " + watermelonScore + "/2   - Coins " + coinScore + "/3";
    }
}
