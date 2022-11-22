using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public bool holdingFood;
    public string heldFood;
    public int wallet;
    public SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (holdingFood)
        {
            sprite.color = Color.white;
        }
        else
        {
            sprite.color = Color.blue;
        }

        if (health < 0)
        {
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

    public void GainMoney(int money)
    {
        wallet += money;
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
