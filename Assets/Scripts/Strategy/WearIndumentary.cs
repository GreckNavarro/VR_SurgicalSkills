
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StrategyPattern
{
    public class WearIndumentary : MonoBehaviour, ITask
    {
        [SerializeField] Material materialToApply;
        [SerializeField] SkinnedMeshRenderer objectWithMaterial1;
        [SerializeField] SkinnedMeshRenderer objectWithMaterial2;

        public void ActivateTask()
        {
            enabled = true;
        }

        public void DesactivateTask()
        {
            TaskSystem.TaskCompleted?.Invoke();
            gameObject.SetActive(false);
        }

        public void TaskToDo()
        {
            Debug.Log("Cogí el guante");

        
            objectWithMaterial1.material = materialToApply;
            objectWithMaterial2.material = materialToApply;

            DesactivateTask();
        }
        private void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("LeftHandCollider") || other.CompareTag("RightHandCollider"))
            {
                TaskToDo();
            }
        }
    }
}

