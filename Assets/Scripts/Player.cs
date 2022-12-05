using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public bool holdingFood;
    public string heldFood;
    public int score;
    public SpriteRenderer sprite;
    private GameObject customer;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (health <= 0)
        {
            transform.position = new Vector3(0, 0, 0);
            health = 100;
        }
    }

    public void TakeFood(string foodType)
    {
        holdingFood = true;
        heldFood = foodType;
    }

    public void DropFood()
    {
        holdingFood = false;
        heldFood = "";
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void GainMoney(int points)
    {
        score += points;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
