using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField] Vector2 sensibility;
    [SerializeField] new Transform camera;
    private float AxisMouseX;
    private float AxisMouseY;
    public float mouseX;
    public float mouseY;
    public float mouseSensitivity = 2f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        

    }

    // Update is called once per frame
    void Update()
    {
        //float hor = Input.GetAxis("Mouse X");
        //float ver = Input.GetAxis("Mouse Y");
        //if (hor != 0)
        //{
        //    transform.Rotate(Vector3.up * hor * sensibility.x);
        //}
        //if (ver != 0)
        //{
        //    float angle = (camera.localEulerAngles.x - ver * sensibility.y + 360) % 360;
        //    if (angle > 180) { angle -= 360; }
        //    angle = Mathf.Clamp(angle, -80, 80);
        //    camera.localEulerAngles = Vector3.right * angle;

        //}
        AxisMouseX = Input.GetAxis("Mouse X");
        AxisMouseY = Input.GetAxis("Mouse Y");
        mouseX = AxisMouseX * mouseSensitivity;
        mouseY = AxisMouseY * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        Vector3 currentRotation = camera.rotation.eulerAngles;
        float desiredRotationX = currentRotation.x - mouseY;
        if (desiredRotationX > 180)
            desiredRotationX -= 360;
        desiredRotationX = Mathf.Clamp(desiredRotationX, -90f, 90f);
        camera.rotation = Quaternion.Euler(desiredRotationX, currentRotation.y, currentRotation.z);
    }
}
