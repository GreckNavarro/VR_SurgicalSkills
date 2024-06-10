using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTaskController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public static Action<bool> OnTaskView;
    public static Action<bool> OnTaskComplete;

    private void OnEnable()
    {
        OnTaskView += AnimationTaskView;
        OnTaskComplete += AnimtionTaskCompleted;
    }
    public void AnimationTaskView(bool comparation)
    {
        animator.SetBool("TaskViewing", comparation);
    }
    public void AnimtionTaskCompleted(bool comparation)
    {
        animator.SetBool("TaskCompleted", comparation);
    }
}
