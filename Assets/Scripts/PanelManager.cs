using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelManager : MonoBehaviour
{
    public TMP_Text TaskTest;
    public HelpMessage[] MessageHelp;
    public static PanelManager instance {  get; private set; }
    private void Awake()
    {
        if(instance != null && instance!=this)
        {
            Destroy(this);
        }else
        {
            instance = this;    
        }
    }
    public void UpdateTaskPending(int index)
    {
        TaskTest.text = MessageHelp[index].TextHelp;
    }
}
