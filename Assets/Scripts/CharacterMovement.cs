using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        onMovement();
    }
    private void onMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 velocity = Vector3.zero;
        if(horizontal != 0 || vertical != 0)
        {
            Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized;
            
            velocity = direction * speed;
        }
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
