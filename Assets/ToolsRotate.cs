using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsRotate : MonoBehaviour
{
  [SerializeField] GameObject correctRotation;
  [SerializeField] GameObject Trocar;
  [SerializeField] Transform cylinder; 
  public float rotationSpeed = 100f;
    public float minRotationAngleX;
  public float maxRotationAngleX;

    public float minRotationAngleZ;
    public float maxRotationAngleZ;
    private Vector3 currentRotation;

   
    public void RotateTrocar(Vector2 axisRightJoystick)
    {
      
            float horizontalInput = axisRightJoystick.y;
            float verticalInput = axisRightJoystick.x;


            if (horizontalInput != 0)
            {
                RotateAroundAxis(Vector3.right, -horizontalInput * rotationSpeed * Time.deltaTime);
            }


            if (verticalInput != 0)
            {
                RotateAroundAxis(Vector3.forward, -verticalInput * rotationSpeed * Time.deltaTime);
            }

            Trocar.transform.rotation = this.transform.rotation;
     
  }

  void RotateAroundAxis(Vector3 axis, float angle)
  {
        Quaternion targetRotation = Quaternion.Euler(currentRotation) * Quaternion.AngleAxis(angle, axis);
        Vector3 proposedEulerAngles = targetRotation.eulerAngles;
        proposedEulerAngles.x = ClampAngle(proposedEulerAngles.x, minRotationAngleX, maxRotationAngleX);
        proposedEulerAngles.z = ClampAngle(proposedEulerAngles.z, minRotationAngleZ, maxRotationAngleZ);
        proposedEulerAngles.y = 0;
        transform.localEulerAngles = proposedEulerAngles;
        currentRotation = transform.localEulerAngles;
  }

  float ClampAngle(float angle, float min, float max)
  {
        angle = Mathf.Repeat(angle, 360f);
        if (angle > 180f)
        {
            angle -= 360f;
        }
        angle = Mathf.Clamp(angle, min, max);
        angle = Mathf.Repeat(angle, 360f);

        return angle;
  }
    
}
