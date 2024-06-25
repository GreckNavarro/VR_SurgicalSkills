using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColedoscopyInteraction : Interactable
{
    [SerializeField] GameObject correctRotation;
    [SerializeField] GameObject Trocar;

    [SerializeField] GameObject holograma;

    [SerializeField] Camera cameraCol;

    bool active = false;

    bool inPosition = false;


    

    [SerializeField] Transform cylinder; 
    public float rotationSpeed = 100f;
    public float minRotationAngle = -10f;
    public float maxRotationAngle = 10f;

    private Vector3 currentRotation;

    private void Start()
    {
        currentRotation = transform.localEulerAngles;
    }

    private void OnEnable()
    {
        PickUp += ChangeBool;
        PickDown += PutPosition;

        XRControllerInput.rightPrimaryAxis2D += RotateTrocar;
        XRControllerInput.rightprimaryButtonPressed += CameraStatic;

    }
    private void OnDisable()
    {
        PickUp -= ChangeBool;
        PickDown -= PutPosition;

        XRControllerInput.rightprimaryButtonPressed -= CameraStatic;


    }



    private void ChangeBool()
    {
        active = !active;
        Interact();
    }

    public void PutPosition(Transform position)
    {
        position.position = holograma.transform.position;
        position.rotation = holograma.transform.rotation;
        holograma.SetActive(false);
        Destroy(holograma);

        inPosition = true;
        GameManager.Instance.ChangeState(GameManager.GameState.Operation);
        cameraCol.gameObject.SetActive(true);


    }

    public void CameraStatic()
    {
        if(inPosition == true)
        XRControllerInput.rightPrimaryAxis2D -= RotateTrocar;
    }
    public override void Interact()
    {

        holograma.SetActive(active);
        this.transform.rotation = correctRotation.transform.rotation;
    }

    public void RotateTrocar(Vector2 axisRightJoystick)
    {
        if(inPosition == true)
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
       



    }

    void RotateAroundAxis(Vector3 axis, float angle)
    {
        Quaternion targetRotation = Quaternion.Euler(currentRotation) * Quaternion.AngleAxis(angle, axis);
        Vector3 proposedEulerAngles = targetRotation.eulerAngles;
        proposedEulerAngles.x = ClampAngle(proposedEulerAngles.x, minRotationAngle, maxRotationAngle);
        proposedEulerAngles.z = ClampAngle(proposedEulerAngles.z, minRotationAngle, maxRotationAngle);
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
