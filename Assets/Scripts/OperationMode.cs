using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationMode : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform positionOperation;

    private void Start()
    {
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.transform.position = positionOperation.position;
    }
}
