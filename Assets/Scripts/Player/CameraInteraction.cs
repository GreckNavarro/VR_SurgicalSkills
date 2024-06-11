using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraInteraction : MonoBehaviour
{
    [SerializeField] Transform leftController;
    [SerializeField] LineRenderer lineRendererleft;
    [SerializeField] Transform righController;
    [SerializeField] LineRenderer lineRendererright;
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask LayerInteraction;

    [SerializeField] bool herramientain = false;
    [SerializeField] GameObject ObjectPick;
    [SerializeField] Transform positionInteraction;
    public bool isOnArea;



    private void OnEnable()
    {
        XRControllerInput.rightGripButtonPressed += GetObject;
        XRControllerInput.rightGripButtonReleased += LeaveObject;
    }
    private void OnDisable()
    {
        XRControllerInput.rightGripButtonPressed -= GetObject;
        XRControllerInput.rightGripButtonReleased -= LeaveObject;
    }

    private void Update()
    {
        lineRendererleft.SetPosition(0, leftController.position);
        lineRendererleft.SetPosition(1, leftController.position + leftController.forward * rayDistance);
        lineRendererright.SetPosition(0, righController.position);
        lineRendererright.SetPosition(1, righController.position + righController.forward * rayDistance);
        Debug.DrawRay(leftController.position, leftController.forward * rayDistance, Color.green);
        Debug.DrawRay(righController.position, righController.forward * rayDistance, Color.green);

     
       
   
    }
    public void DebugC()
    {
       
    }
    public void GetObject()
    {
        Debug.Log("Hola Obetener Objeto");
        RaycastHit hit;
        if (Physics.Raycast(righController.position, righController.forward, out hit, rayDistance, LayerInteraction))
        {
            if (ObjectPick == null)
            {
                
                ObjectPick = hit.transform.gameObject;
                ObjectPick.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                ObjectPick.transform.SetParent(positionInteraction);
                ObjectPick.transform.position = positionInteraction.position;
                ObjectPick.transform.rotation = positionInteraction.rotation;
                ObjectPick.GetComponent<Collider>().isTrigger = true;
                ObjectPick.GetComponent<Interactable>().PickUp?.Invoke();
                ObjectPick.GetComponent<Rigidbody>().useGravity = false;
                ObjectPick.GetComponent<Rigidbody>().isKinematic = true;
                herramientain = true;
            }
            
        }
    }
    public void LeaveObject()
    {
        Debug.Log("Hola Dejar Objeto");
        if (ObjectPick != null)
        {
            ObjectPick.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
            if (isOnArea)
            {
                ObjectPick.transform.SetParent(null);
                ObjectPick.GetComponent<Interactable>().PickDown?.Invoke(ObjectPick.transform);
                ObjectPick.layer = default;
                ObjectPick = null;
                herramientain = false;
                Debug.Log("Termine");
            }
            else
            {
                ObjectPick.transform.SetParent(null);
                ObjectPick.GetComponent<Rigidbody>().useGravity = true;
                ObjectPick.GetComponent<Rigidbody>().isKinematic = false;
                ObjectPick.GetComponent<Collider>().isTrigger = false;
                ObjectPick.GetComponent<Interactable>().PickUp?.Invoke();
                ObjectPick = null;
                herramientain = false;
            }
        }
       
        
    }
 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hola");
        if (other.CompareTag("AreaBody"))
        {
            if (ObjectPick != null)
            {
                isOnArea = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AreaBody"))
        {
            isOnArea = false;
        }
    }
}
