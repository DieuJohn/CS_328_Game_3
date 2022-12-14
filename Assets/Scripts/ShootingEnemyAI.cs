using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyAI : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float retreatDistance;
    public float stoppingDistance;

    public GameObject fireSpot;
    public SpriteRenderer changeSprite;

    public GameObject projectile;
    public Sprite normalSprite;
    public Sprite fireSprite;
    public float timeBetweenShotsMin;
    public float timeBetweenShotsMax;
    private float nextShotTime;

    AudioSource fireSound;
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        fireSound = GetComponent<AudioSource>();
        changeSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    IEnumerator shootSpriteReturnDelay()
    {
        yield return new WaitForSeconds(0.1f);

        changeSprite.sprite = normalSprite;
    }
    void Update()
    {

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;
        direction.Normalize();

        //Shoots
        if (Time.time > nextShotTime)
        {
            fireSound.pitch = Random.Range(0.9f, 1.2f);
            fireSound.Play();
            Instantiate(projectile, fireSpot.transform.position, Quaternion.identity);
            //timeBetweenShots
            nextShotTime = Time.time + Random.Range(timeBetweenShotsMin, timeBetweenShotsMax); ;

            changeSprite.sprite = fireSprite;
            StartCoroutine(shootSpriteReturnDelay());
        }

        //Retreat and Chase movement
        if(Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
