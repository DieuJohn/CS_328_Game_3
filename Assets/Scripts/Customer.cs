using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : Interactable
{
    public bool complete = false;
    public string order;
    public int money = 10;

    public GameObject foodIcon;
    private AudioSource cashSound;

    protected override void Interact()
    {
        GameObject icon = Instantiate(this.foodIcon, this.transform) as GameObject;
        icon.transform.localPosition = new Vector2(icon.transform.localPosition.x + 1, icon.transform.localPosition.y - 2);
        cashSound = GetComponent<AudioSource>();

        if (!complete)
        {
            if (player.heldFood == order)
            {
                complete = true;
                player.DropFood();
                player.GainMoney(money);
                sprite.color = Color.green;
                cashSound.Play();
                this.gameObject.SetActive(false);
                Destroy(icon);
            }
        }
    }
}

