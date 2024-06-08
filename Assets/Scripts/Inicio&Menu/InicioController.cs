using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InicioController : MonoBehaviour
{
    [SerializeField] SoundSelectionSO mySoundSelection;

    void Update()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                mySoundSelection.StartSoundSelection();
                ChargeLevelController.OnLevelLoad?.Invoke(1);
            }
        }
    }
}
