using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Handle", menuName = "Handle/Message")]
public class HandleMessages : ScriptableObject
{
    public event Action ActionGeneral;
    public event Action<GameObject> ActionActivateCanvas;
    public void CallEventGeneral()
    {
        ActionGeneral?.Invoke();
    }
    public void CallEventActivateCanvas(GameObject optionPanel)
    {
        ActionActivateCanvas?.Invoke(optionPanel);
    }
}
