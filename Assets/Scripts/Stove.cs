using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stove : Interactable
{
    public float cookTime;
    private float timer;
    public bool timerIsRunning = false;
    private bool ready = false;
    public string food;
    public UnityEvent emptyAction;
    public UnityEvent readyAction;
    private Player player;

    protected override void OnCollide(Collider2D coll)
    {        
        if (coll.name == "Player" && Input.GetKey(KeyCode.E))
        {
            player = coll.GetComponent<Player>();
            Interact(player.heldFood);
        }
    }

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
            }
            else
            {
                Debug.Log("Finished Cooking");
                timer = cookTime;
                timerIsRunning = false;
                ready = true;
                food = "Cooked " + food;
            }
        }
    }

    protected virtual void Interact(string heldFood)
    {
        //Starts timer if player has a Wing and is not currently running.
        if (timerIsRunning == false && heldFood == "Wing")
        {
            food = heldFood;
            timerIsRunning = true;
            timer = cookTime;
            emptyAction.Invoke();
        }
        //Removes the ready flag and stored food item, gives player food.
        else if (ready && player.heldFood == "")
        {
            ready = false;
            player.TakeFood(food);
            food = "";
        }
    }
}
