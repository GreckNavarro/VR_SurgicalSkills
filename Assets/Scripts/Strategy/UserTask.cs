using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StrategyPattern;

public class UserTask : MonoBehaviour
{
    public Context context;
    public List<GameObject> tasks;
    // Start is called before the first frame update
    void Awake()
    {
    }
    private void Start()
    {
        context.SetITask(tasks[0].GetComponent<ITask>());
        context.ActivateTask();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
