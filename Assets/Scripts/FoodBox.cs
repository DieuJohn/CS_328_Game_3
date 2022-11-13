using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodBox : Interactable
{
    public UnityEvent interactAction;
    private Player player;

    protected override void OnCollide(Collider2D coll)
    {
        Player player = coll.GetComponent<Player>();

        if (coll.name == "Player" && Input.GetKey(KeyCode.E))
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {
        interactAction.Invoke();
    }
}
