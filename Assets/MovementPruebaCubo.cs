using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPruebaCubo : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody myrb;

    public Transform sphere;
    float accumulatedRotationZ;

    private void Start()
    {
        myrb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizonta = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Aplicar movimiento al cubo
        myrb.velocity = new Vector3(horizonta * speed, 0f, vertical * speed);

        // Calcular la rotaci�n acumulativa de la esfera en Z
        float rotationAmount = horizonta * 30f * Time.deltaTime; // Ajusta el factor de rotaci�n seg�n tu preferencia

        // Acumular la rotaci�n en Z
        accumulatedRotationZ += rotationAmount;

        // Aplicar la rotaci�n acumulada a la esfera
        sphere.rotation = Quaternion.Euler(0f, 0f, accumulatedRotationZ);
    }
}
