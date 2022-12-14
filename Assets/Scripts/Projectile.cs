using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public AudioClip bulletHit;
    public AudioClip playerHurt;

    Vector3 targetPosition;
    public float speed;
    public Rigidbody2D rb;
    Vector3 moveDir;
    public int damage;

    AudioSource ricochetSound;
    AudioSource hurtSound;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        targetPosition = FindObjectOfType<PlayerMovement>().transform.position;
        moveDir = (targetPosition - transform.position).normalized;
        ricochetSound = GetComponent<AudioSource>();
        hurtSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Renderer invisible;
        Renderer trailRenderer;

        switch (other.gameObject.tag)
        {
            case "Wall":
                //Play sound
                ricochetSound.clip = bulletHit;

                ricochetSound.pitch = Random.Range(0.9f, 1.2f);
                ricochetSound.Play();

                invisible = GetComponent<SpriteRenderer>();
                invisible.enabled = false;

                trailRenderer = GetComponent<TrailRenderer>();
                trailRenderer.enabled = false;

                //Delay before destroy
                StartCoroutine(timeTilDestroy());

                break;
            case "Player":
                other.gameObject.GetComponent<Player>().TakeDamage(damage);
                //Play sound
                ricochetSound.clip = playerHurt;

                ricochetSound.pitch = Random.Range(0.9f, 1.2f);
                ricochetSound.Play();

                invisible = GetComponent<SpriteRenderer>();
                invisible.enabled = false;

                trailRenderer = GetComponent<TrailRenderer>();
                trailRenderer.enabled = false;

                //Delay before destroy
                StartCoroutine(timeTilDestroy());

                break;
        }
    }

    IEnumerator timeTilDestroy()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

}
