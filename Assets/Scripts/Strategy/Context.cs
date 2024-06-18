using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StrategyPattern;
public class Context : MonoBehaviour, ITask
{
    private ITask currentTask;
    public void SetITask(ITask task)
    {
        currentTask = task;
        Debug.Log(currentTask);
        Debug.Log("Se estableció la tarea: " + currentTask.GetType().Name);
    }
    public void ActivateTask()
    {
        currentTask.ActivateTask();
    }

    public void DesactivateTask()
    {
        currentTask.DesactivateTask();
    }

    public void TaskToDo()
    {
        currentTask.TaskToDo();
    }
}
