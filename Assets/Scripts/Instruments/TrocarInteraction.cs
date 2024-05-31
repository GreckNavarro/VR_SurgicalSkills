using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TrocarInteraction : Interactable
{
    public  Action prenderHolograma;
    public Action offHologram;
    public Action<Transform> hologramIdeal;
    [SerializeField] GameObject holograma;
    bool active = false;

    
    
    
    

    private void OnEnable()
    {
        prenderHolograma += ChangeBool;
        hologramIdeal += PutPosition;
    }
    private void OnDisable()
    {
        prenderHolograma -= ChangeBool;
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
    }

}
