using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColedoscopyInteraction : Interactable
{
    [SerializeField] GameObject correctRotation;

    [SerializeField] GameObject holograma;

    [SerializeField] Camera cameraCol;

    bool active = false;

    bool inPosition = false;


    //ROTATE

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
    }
    private void OnDisable()
    {
        PickUp -= ChangeBool;
        PickDown -= PutPosition;
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
        cameraCol.gameObject.SetActive(true);


    }
    private void Update()
    {
        if(inPosition == true && (GameManager.Instance.CurrentState == GameManager.GameState.Operation))
        {
            RotateTrocar();
        }
    }
    public override void Interact()
    {

        holograma.SetActive(active);
        this.transform.rotation = correctRotation.transform.rotation;
    }

    public void RotateTrocar()
    {
        if (Input.GetKey(KeyCode.W))
        {
            RotateAroundAxis(Vector3.right, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            RotateAroundAxis(Vector3.right, -rotationSpeed * Time.deltaTime);
        }

        // Rotación en el eje Z
        if (Input.GetKey(KeyCode.A))
        {
            RotateAroundAxis(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            RotateAroundAxis(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
    }

    void RotateAroundAxis(Vector3 axis, float angle)
    {
        // Calcular la nueva rotación propuesta
        Quaternion targetRotation = Quaternion.Euler(currentRotation) * Quaternion.AngleAxis(angle, axis);

        // Obtener los ángulos eulerianos de la rotación propuesta
        Vector3 proposedEulerAngles = targetRotation.eulerAngles;

        // Limitar la rotación en el eje X dentro del rango especificado
        proposedEulerAngles.x = ClampAngle(proposedEulerAngles.x, minRotationAngle, maxRotationAngle);

        // Limitar la rotación en el eje Z dentro del rango especificado
        proposedEulerAngles.z = ClampAngle(proposedEulerAngles.z, minRotationAngle, maxRotationAngle);

        // Aplicar la rotación
        transform.localEulerAngles = proposedEulerAngles;

        // Actualizar la rotación actual
        currentRotation = transform.localEulerAngles;
    }

    float ClampAngle(float angle, float min, float max)
    {
        // Normalizar el ángulo al rango [0, 360)
        angle = Mathf.Repeat(angle, 360f);

        // Ajustar el ángulo para que esté dentro del rango [min, max]
        if (angle > 180f)
        {
            angle -= 360f;
        }

        angle = Mathf.Clamp(angle, min, max);

        // Convertir el ángulo de vuelta al rango [0, 360) antes de devolverlo
        angle = Mathf.Repeat(angle, 360f);

        return angle;
    }
}
