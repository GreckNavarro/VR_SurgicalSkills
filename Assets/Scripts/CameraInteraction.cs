using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask LayerInteraction;

    [SerializeField] bool herramientain = false;
    [SerializeField] GameObject ObjectPick;
    [SerializeField] Transform positionInteraction;



    private void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.green);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(herramientain == false)
            {
                GetObject();
            }
            else
            {
                DejarObject();
            }
            
        }
    }
    public void GetObject()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerInteraction))
        {
            if(ObjectPick == null)
            {
                ObjectPick = hit.transform.gameObject;
                ObjectPick.transform.SetParent(positionInteraction);
                ObjectPick.transform.position = positionInteraction.position;
                ObjectPick.transform.rotation = positionInteraction.rotation;
                ObjectPick.GetComponent<Collider>().isTrigger = true;
                ObjectPick.GetComponent<Rigidbody>().useGravity = false;
                ObjectPick.GetComponent<Rigidbody>().isKinematic = true;
                herramientain = true;
            }

        }
    }
    public void DejarObject()
    {
        ObjectPick.transform.SetParent(null);


        ObjectPick.GetComponent<Rigidbody>().useGravity = true;
        ObjectPick.GetComponent<Rigidbody>().isKinematic = false;
        ObjectPick.GetComponent<Collider>().isTrigger = false;
        ObjectPick = null;
        herramientain = false;
    }
}
