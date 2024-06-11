using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    public Action PickUp;
    public Action<Transform> PickDown;
    public virtual void Interact()
    {

    }
}
