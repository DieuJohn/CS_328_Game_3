using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Interactable
{
    //inherits from the iteractable script, has a changeable accepted food.
    public float cookTime;
    private float timer;
    public bool timerIsRunning = false;
    private bool ready = false;
    public string food;
    public string takenFood;
    private string heldFood;
    //note: move to base interactable script 


    protected override void Update()
    {
        //carryover collider analysis to add a timer to update function, probably a better way to do this
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
        //timer for cooking, turns food cooked when completed.
        if (timerIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                sprite.sprite = newSprite;
            }
            else
            {
                Debug.Log("Finished Cooking");
                timer = cookTime;
                timerIsRunning = false;
                ready = true;
                food = "Cooked " + food;
                sprite.sprite = defaultSprite;
            }
        }
    }

    protected override void Interact()
    {
        heldFood = player.heldFood;
        //Starts timer if player has food that is taken by the stove and takes their food..
        if (timerIsRunning == false && heldFood == takenFood)
        {
            food = heldFood;
            timerIsRunning = true;
            timer = cookTime;
            player.DropFood();
        }
        //Removes the ready flag and stored food item, gives player cooked food.
        else if (ready && player.heldFood == "")
        {
            ready = false;
            player.TakeFood(food);
            food = "";
        }
    }
}
