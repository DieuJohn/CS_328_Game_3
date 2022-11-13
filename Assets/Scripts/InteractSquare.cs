using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSquare : Interactable
{
    private bool Interacted = false;
    public Sprite interacted;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player" && Input.GetKey(KeyCode.E))
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {
        if (Interacted == false)
        {
            Interacted = true;
            GetComponent<SpriteRenderer>().sprite = interacted;
            Debug.Log("Interacted with " + name);
        }
    }
}
