using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                ChargeLevelController.instance.FadeToLevel(1);
            }
        }
    }
}
