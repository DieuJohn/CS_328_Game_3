using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyToText : MonoBehaviour
{
    private GameObject player;
    public TMP_Text moneyText;
    public TMP_Text healthText;
    private Player playerComp;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerComp = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Wallet: " + playerComp.wallet.ToString();
        healthText.text = "Health: " + playerComp.health.ToString();
    }
}
