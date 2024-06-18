using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{
    public class CleanHands : MonoBehaviour, ITask
    {
        public int numberOfHands;
        public float FrameRate;
        public int Timer;

        private void Update()
        {
            if (numberOfHands == 2)
            {
                TaskToDo();
            }
        }
        public void ActivateTask()
        {
            enabled = true;   
        }

        public void DesactivateTask()
        {
            TaskSystem.TaskCompleted?.Invoke();
            enabled = false;
        }
        public void TaskToDo()
        {
            FrameRate += Time.deltaTime;
            if (FrameRate >= Timer)
            {
                Debug.Log("Me lave las manos");
                FrameRate = 0;
                DesactivateTask();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("LeftHandCollider"))
            {
                numberOfHands += 1;
            }
            if (other.CompareTag("RightHandCollider"))
            {
                numberOfHands += 1;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("LeftHandCollider"))
            {
                numberOfHands -= 1;
            }
            if (other.CompareTag("RightHandCollider"))
            {
                numberOfHands -= 1;
            }
        }
    }
}
