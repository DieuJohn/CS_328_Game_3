using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyToText : MonoBehaviour
{
    private GameObject player;
    public TMP_Text moneyText;
    public TMP_Text healthText;
    public TMP_Text endScore;
    public TMP_Text endHighScore;
    private Player playerComp;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerComp = player.GetComponent<Player>();
    }

    void Update()
    {
        moneyText.text = "Score: " + playerComp.score.ToString();
        healthText.text = "Health: " + playerComp.health.ToString();
        endScore.text = "SCORE: " + playerComp.score.ToString();
        endHighScore.text = $"HIGH SCORE:  {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
