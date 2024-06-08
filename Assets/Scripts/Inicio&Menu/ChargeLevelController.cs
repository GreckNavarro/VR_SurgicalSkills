using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChargeLevelController : MonoBehaviour
{
    Animator animator;
    private int levelToLoad;
    public static Action<int> OnLevelLoad;
    // Start is called before the first frame update
    private void OnEnable()
    {
        OnLevelLoad += FadeToLevel;
    }
    private void OnDisable()
    {
        OnLevelLoad -= FadeToLevel;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    } 
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
