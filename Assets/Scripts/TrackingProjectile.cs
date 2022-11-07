using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingProjectile : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;
    public Rigidbody2D rb;
    Vector3 moveDir;
    public int damage;
    public float trackTime;
    private float endTrackTime;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        targetPosition = FindObjectOfType<PlayerMovement>().transform.position;
        moveDir = (targetPosition - transform.position).normalized;
        endTrackTime = Time.time + trackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < endTrackTime)
        {
            targetPosition = FindObjectOfType<PlayerMovement>().transform.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Time.time > endTrackTime)
        {
            if(transform.position == targetPosition)
            {
                Destroy(gameObject);
            }
        }
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
