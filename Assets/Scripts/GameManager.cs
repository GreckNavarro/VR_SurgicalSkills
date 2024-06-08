using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GenerateTask(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GenerateTask(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GenerateTask(2);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            GenerateTask(3);
        }
    }
    public async void GenerateTask(int index)
    {
        Debug.Log("Empezando");
        PanelManager.instance.UpdateTaskPending(index);
        AnimTaskController.OnTaskView?.Invoke(true);
        await PendingTask();
    }
    public async Task PendingTask()
    {
        Debug.Log("Entrando a la tarea");
        await Task.Delay(1000);
        AnimTaskController.OnTaskView?.Invoke(false);
        AnimTaskController.OnTaskComplete?.Invoke(true);
        Debug.Log("Termine");
        await Task.Delay(1000);
        AnimTaskController.OnTaskComplete?.Invoke(false);
    }
}
