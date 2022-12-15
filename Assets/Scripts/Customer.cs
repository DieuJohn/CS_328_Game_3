using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : Interactable
{
    public bool complete = false;
    public string order;
    public int money = 10;

    public GameObject foodIcon;

    protected override void Interact()
    {
        GameObject icon = Instantiate(this.foodIcon, this.transform) as GameObject;
        icon.transform.localPosition = new Vector2(icon.transform.localPosition.x + 1, icon.transform.localPosition.y - 2);

        if (!complete)
        {
            if (player.heldFood == order)
            {
                complete = true;
                player.DropFood();
                player.GainMoney(money);
                sprite.color = Color.green;
                this.gameObject.SetActive(false);
                Destroy(icon);
            }
        }
    }
}

