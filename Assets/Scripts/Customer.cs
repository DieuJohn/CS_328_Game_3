using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : Interactable
{
    public bool complete = false;
    private Player player;
    public string order;
    public int money = 10;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player" && Input.GetKey(KeyCode.E))
        {
            player = coll.GetComponent<Player>();
            Interact();
        }
    }

    protected virtual void Interact()
    {
        if (!complete)
        {
            if (player.heldFood == order)
            {
                complete = true;
                player.DropFood();
                player.GainMoney(money);
                sprite.color = Color.green;
            }
        }
    }
}
