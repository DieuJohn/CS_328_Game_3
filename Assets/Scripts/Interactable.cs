using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Base interactable script for all interactable scripts to inherit from.
    public ContactFilter2D filter;
    protected BoxCollider2D boxCollider;
    protected Collider2D[] hits = new Collider2D[10];
    public SpriteRenderer sprite;
    public GameObject foodSprite;
    public Sprite newSprite;
    protected Sprite defaultSprite;

    protected virtual void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        defaultSprite = sprite.sprite;
    }

    protected virtual void Update()
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            OnCollide(hits[i]);

            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("Interacted with " + coll.name);
    }
}
