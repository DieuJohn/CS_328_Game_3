using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Vector3 targetPosition;
    public float speed;
    public Rigidbody2D rb;
    Vector3 moveDir;
    public int damage;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        targetPosition = FindObjectOfType<PlayerMovement>().transform.position;
        moveDir = (targetPosition - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Player":
                other.gameObject.GetComponent<Player>().TakeDamage(damage);
                Destroy(gameObject);
                break;
        }
    }
}
