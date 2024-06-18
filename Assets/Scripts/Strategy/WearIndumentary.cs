
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StrategyPattern
{
    public class WearIndumentary : MonoBehaviour, ITask
    {
        [SerializeField] SkinnedMeshRenderer materialToApply;
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

            // Clonar los materiales para evitar cambiar el material original
            Material[] newMaterials = new Material[materialToApply.materials.Length];
            for (int i = 0; i < materialToApply.materials.Length; i++)
            {
                newMaterials[i] = new Material(materialToApply.materials[i]);
            }

            // Aplicar los materiales clonados a los objetos objetivo
            objectWithMaterial1.materials = newMaterials;
            objectWithMaterial2.materials = newMaterials;

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

