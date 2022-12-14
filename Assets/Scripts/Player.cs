using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public bool holdingFood;
    public string heldFood;
    public int score;
    public SpriteRenderer sprite;
    private GameObject customer;

    public SpriteRenderer foodSprite;
    public Sprite waffle;
    public Sprite wing;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (health <= 0)
        {
            transform.position = new Vector3(0, 0, 0);
            health = 100;
        }
    }

    public void TakeFood(string foodType)
    {
        holdingFood = true;
        heldFood = foodType;
        FoodSprite(heldFood);
    }

    public void FoodSprite(string foodType)
    {
        if (foodType == "Waffle")
        {
            foodSprite.sprite = waffle;
        }
        else if (foodType == "Wing")
        {
            foodSprite.sprite = wing;
        }
        else
        {
            foodSprite.sprite = null;
        }
    }

    public void DropFood()
    {
        holdingFood = false;
        heldFood = "";
        FoodSprite(heldFood);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        sprite.color = new Color(255, 0, 0);
        StartCoroutine(damageFlash());

    }
    IEnumerator damageFlash()
    {
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(255, 255, 255);
    }

    public void GainMoney(int points)
    {
        score += points;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
