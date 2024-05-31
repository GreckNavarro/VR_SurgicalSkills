using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigurationController : MonoBehaviour
{
    [SerializeField] private SoundsSO[] sonidos;
    [SerializeField] private Slider[] sliders;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sonidos.Length; i++)
        {
            sonidos[i].cargarPreferencia.Invoke(sliders[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
