using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrocarInteraction : Interactable
{
    public  Action prenderHolograma;
    public Action offHologram;
    [SerializeField] GameObject holograma;
    bool active = false;

    private void OnEnable()
    {
        prenderHolograma += ChangeBool;
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

    public override void Interact()
    {
     
        holograma.SetActive(active);
    }

}
