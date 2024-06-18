using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCleandHands : TaskFactory
{
    public CleanHands hands1;
    public void SetCleanHands(CleanHands hands) 
    {
        hands1 = hands;
    }
    public override void ActivateTask()
    {
        hands1.ActivateTask();
    }
}
