using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        ChargeLevelController.instance.FadeToLevel(2);
    }
    public void Leave()
    {
        Application.Quit();
    }
}
