using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVR : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody myrb;
    public bool moveInY = false;
    public float speedRotation;

    private void OnEnable()
    {
        XRControllerInput.rightPrimaryAxis2D += Rotate;
        XRControllerInput.leftPrimaryAxis2D += Movement;
    }
    private void OnDisable()
    {
        XRControllerInput.rightPrimaryAxis2D -= Rotate;
        XRControllerInput.leftPrimaryAxis2D -= Movement;
    }

    private void Start()
    {
        myrb = GetComponent<Rigidbody>();
    }
    public void Rotate(Vector2 axisRightJoystick)
    {
        float rotateY = axisRightJoystick.x;
        transform.Rotate(rotateY * Vector3.up, Space.World);
    }
    public void Movement(Vector2 axisRightJoystick)
    {
        float horizontalInput = axisRightJoystick.x;
        float verticalInput = axisRightJoystick.y;
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f; 
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 direction = (camForward * verticalInput + camRight * horizontalInput).normalized * speed;
        myrb.velocity = direction * speed;
    }


}
