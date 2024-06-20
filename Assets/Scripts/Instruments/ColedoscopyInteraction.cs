using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColedoscopyInteraction : Interactable
{
    [SerializeField] GameObject correctRotation;

    [SerializeField] GameObject holograma;
    bool active = false;


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
    }
    public override void Interact()
    {

        holograma.SetActive(active);
        this.transform.rotation = correctRotation.transform.rotation;
    }
}
