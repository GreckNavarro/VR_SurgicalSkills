using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolActive : MonoBehaviour
{
    [SerializeField] ToolsRotate Tool1;
    [SerializeField] ToolsRotate Tool2;

    
    private void OnEnable()
    {
        Tool1.gameObject.SetActive(true);
        Tool2.gameObject.SetActive(true);
        XRControllerInput.rightPrimaryAxis2D += Tool2.RotateTrocar;
        XRControllerInput.leftPrimaryAxis2D += Tool1.RotateTrocar;
    }
    private void OnDisable()
    {
        XRControllerInput.rightPrimaryAxis2D -= Tool2.RotateTrocar;
        XRControllerInput.leftPrimaryAxis2D -= Tool1.RotateTrocar;
    }
}
