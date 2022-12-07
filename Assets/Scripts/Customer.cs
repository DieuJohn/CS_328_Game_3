using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : Interactable
{
    public bool complete = false;
    public string order;
    public int money = 10;



    protected override void Interact()
    {
        if (!complete)
        {
            if (player.heldFood == order)
            {
                complete = true;
                player.DropFood();
                player.GainMoney(money);
                sprite.color = Color.green;
                this.gameObject.SetActive(false);
            }
        }
    }
}

