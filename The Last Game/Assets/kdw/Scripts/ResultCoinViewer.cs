using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultCoinViewer : MonoBehaviour
{
    private TextMeshProUGUI textResultCoin;

    private void Awake()
    {
        textResultCoin = GetComponent<TextMeshProUGUI>();
        int coin = PlayerPrefs.GetInt("Coin");
        textResultCoin.text = "Coin " + coin;
    }
}
