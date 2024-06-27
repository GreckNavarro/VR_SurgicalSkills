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


    [SerializeField] GameObject Tablet;
    bool TaskActive = false;


    private void Start()
    {
        TaskActive = false;
    }

    private void OnEnable()
    {
        XRControllerInput.rightGripButtonPressed += GetObject;
        XRControllerInput.rightGripButtonReleased += LeaveObject;

        XRControllerInput.rightprimaryButtonPressed += TaskGameObjectActive;
        XRControllerInput.rightsecondaryButtonPressed += TestTaskUnderline;

    }
    private void OnDisable()
    {
        XRControllerInput.rightGripButtonPressed -= GetObject;
        XRControllerInput.rightGripButtonReleased -= LeaveObject;

        XRControllerInput.rightprimaryButtonPressed -= TaskGameObjectActive;
        XRControllerInput.rightsecondaryButtonPressed -= TestTaskUnderline;

        

    }


    public void TestTaskUnderline()
    {
        TaskSystem.TaskCompleted?.Invoke();

    }



    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameManager.GameState.Operation)
        {
            lineRendererleft.SetPosition(0, leftController.position);
            lineRendererleft.SetPosition(1, leftController.position + leftController.forward * rayDistance);
            lineRendererright.SetPosition(0, righController.position);
            lineRendererright.SetPosition(1, righController.position + righController.forward * rayDistance);
            Debug.DrawRay(leftController.position, leftController.forward * rayDistance, Color.green);
            Debug.DrawRay(righController.position, righController.forward * rayDistance, Color.green);
            Debug.Log(GameManager.Instance.CurrentState);
                
        }
        else
        {
            lineRendererleft.enabled = false;
            lineRendererright.enabled = false;
        }
           
   
    }
    
    public void TaskGameObjectActive()
    {
        if(GameManager.Instance.CurrentState != GameManager.GameState.Operation)
        {
            lineRendererleft.enabled = TaskActive;
            lineRendererright.enabled = TaskActive;
            TaskActive = !TaskActive;
            Tablet.gameObject.SetActive(TaskActive);
        }


    }
    public void GetObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(righController.position, righController.forward, out hit, rayDistance, LayerInteraction))
        {
            if (ObjectPick == null)
            {
                
                ObjectPick = hit.collider.gameObject;
                ObjectPick.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                ObjectPick.transform.position = positionInteraction.position;
                ObjectPick.transform.SetParent(positionInteraction);
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
            }
            else
            {
                ObjectPick.transform.SetParent(null);
                ObjectPick.GetComponent<Rigidbody>().useGravity = true;
                ObjectPick.GetComponent<Rigidbody>().isKinematic = false;
                ObjectPick.GetComponent<Collider>().isTrigger = false;
                Debug.Log(ObjectPick.gameObject);
                ObjectPick.GetComponent<Interactable>().PickUp?.Invoke();
                ObjectPick = null;
                herramientain = false;
            }
        }
       
        
    }
 
    private void OnTriggerEnter(Collider other)
    {
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
