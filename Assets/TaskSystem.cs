using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TaskSystem : MonoBehaviour
{
    [SerializeField] List<TMP_Text> TaskList;
    [SerializeField] List<Toggle> TogglesTask;
    public static Action TaskCompleted;

    TMP_Text currentText;
    Toggle currentToggle;
    public int index;

    private void OnEnable()
    {
        TaskCompleted += NextTask;
    }
    private void OnDisable()
    {
        TaskCompleted -= NextTask;
    }

    private void Start()
    {
        index = 0;
        currentText = TaskList[index];
        currentToggle = TogglesTask[index];
    }

    public void NextTask()
    {
        currentText.fontStyle = FontStyles.Strikethrough;
        currentToggle.isOn = true;

        if (index < TaskList.Count - 1)
        {
            index++;
            currentText = TaskList[index];
            currentToggle = TogglesTask[index];
        }
        else
        {
            Debug.Log("Ya no hay mas tareas");
        }
    }




}
