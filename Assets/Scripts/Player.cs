using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public bool holdingFood;
    public string heldFood;
    public int wallet;

    void Start()
    {
    
    }

    void Update()
    {
        
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
}
