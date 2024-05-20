using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChargeLevelController : MonoBehaviour
{
    Animator animator;
    private int levelToLoad;
    public static ChargeLevelController instance { get; private set; }
    private void Awake()
    {
        if(instance != null && instance!=this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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
