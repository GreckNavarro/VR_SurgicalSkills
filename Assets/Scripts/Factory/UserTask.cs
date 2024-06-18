using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTask : MonoBehaviour
{
    public TaskFactory factory;
    // Start is called before the first frame update
    void Awake()
    {
    }
    private void Start()
    {
        factory = GetComponent<FactoryCleandHands>();

        factory.ActivateTask();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
