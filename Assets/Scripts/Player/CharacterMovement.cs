using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] FootStepSound footstep;

    //private void OnEnable()
    //{
    //    XRControllerInput.rightPrimaryAxis2D += onMovement;
    //}
    //private void OnDisable()
    //{
    //    XRControllerInput.rightPrimaryAxis2D -= onMovement;
    //}


    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //private void onMovement(Vector2 vectorInput)
    //{
    //    float horizontal = vectorInput.x;
    //    float vertical = vectorInput.y;
    //    Vector3 move = transform.right * horizontal + transform.forward * vertical;
    //    Vector3 velocity = Vector3.zero;
    //    if(horizontal != 0 || vertical != 0)
    //    {
    //        Vector3 direction = move;
            
    //        velocity = direction * speed;
    //        footstep.PlayFootstepSound();
    //    }
    //    else
    //    {
    //        footstep.StopFootStepSound();
    //    }
    //    velocity.y = rb.velocity.y;
    //    rb.velocity = velocity;
    //}
}
