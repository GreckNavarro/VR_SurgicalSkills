using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] HandleMessages OnPlay;
    [SerializeField] HandleMessages OnLeave;
    [SerializeField] HandleMessages OnOption;
    private bool activeOptions =false;
    [SerializeField] SoundSelectionSO soundSelectionSO;
    private void OnEnable()
    {
        OnPlay.ActionGeneral += Play;
        OnLeave.ActionGeneral += Leave;
        OnOption.ActionActivateCanvas +=Options;
    }

    private void Play()
    {
        soundSelectionSO.StartSoundSelection();
        ChargeLevelController.OnLevelLoad?.Invoke(2);
    }
    private void Leave()
    {
        //soundSelectionSO.StartSoundSelection();
        Application.Quit();
    }
    private void Options(GameObject panel)
    {
        if(activeOptions==false) 
        {
            soundSelectionSO.StartSoundSelection();
            panel.SetActive(true);
            activeOptions = true;
        }else if(activeOptions==true)
        {
            soundSelectionSO.StartSoundSelection();
            panel.SetActive(false);
            activeOptions = false;
        }
    }
}
