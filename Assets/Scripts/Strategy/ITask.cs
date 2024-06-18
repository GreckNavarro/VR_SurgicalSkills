using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{
    public interface ITask
    {
        void ActivateTask();
        void DesactivateTask();
        void TaskToDo();

    }
}

