using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    Vector2 movement;

    public float walkSpeed = 4f;
    public float rotationSpeed = 720f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //movement normalized
        float inputMagnitude = Mathf.Clamp01(movement.magnitude);
        movement.Normalize();
        transform.Translate(movement * walkSpeed * inputMagnitude * Time.deltaTime, Space.World);

        //rotation
        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, -movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

}
