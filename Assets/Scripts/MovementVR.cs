using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVR : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform cameraTransform;
    public bool moveInY = false;
    public float speedRotation;

    private void OnEnable()
    {
        XRControllerInput.rightPrimaryAxis2D += DebugValue;
    }
    private void OnDisable()
    {
        XRControllerInput.rightPrimaryAxis2D -= DebugValue;
    }

    public void DebugValue(Vector2 axisRightJoystick)
    {
        Debug.Log(axisRightJoystick);
    }
    void Update()
    {
        Vector3 moveDirection = cameraTransform.forward;

        if (!moveInY)
        {
            moveDirection.y = 0;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = -1 * (moveDirection * verticalInput + cameraTransform.right * horizontalInput) * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
