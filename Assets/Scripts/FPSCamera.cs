using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField] Vector2 sensibility;
    [SerializeField] new Transform camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        

    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");
        if(hor != 0)
        {
            transform.Rotate(Vector3.up * hor * sensibility.x);
        }
        if(ver != 0)
        {
            float angle = (camera.localEulerAngles.x - ver * sensibility.y + 360) % 360;
            if(angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -80, 80);
            camera.localEulerAngles = Vector3.right * angle;

        }
    }
}
