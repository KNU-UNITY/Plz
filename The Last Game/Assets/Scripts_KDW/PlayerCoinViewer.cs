using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCoinViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerController PlayerController;
    private TextMeshProUGUI coinScore;

    private void Awake()
    {
        coinScore = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        coinScore.text = "Coin " + PlayerController.Coin;
    }
}
