using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class stolenPointSystem : MonoBehaviour
{
    public static int appleScore = 0;
    public static int watermelonScore = 0;
    public static int coinScore = 0;

    public TextMeshProUGUI score;

    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        score.text = "- Apple " + appleScore + "/3            - Watermelon " + watermelonScore + "/2   - Coins " + coinScore + "/2";
    }
}
