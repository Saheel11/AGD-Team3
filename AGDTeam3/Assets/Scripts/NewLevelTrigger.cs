using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelTrigger : MonoBehaviour
{
    public Canvas _newLevel;

    private int currentSceneIndex;
    private int nextSceneIndex;

    public Animator transition;

    [SerializeField]
    private float transistionTime = 1f;

    private void Start()
    {
        _newLevel.enabled = false;
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;

    }

    private void OnTriggerEnter(Collider other)
    {
        _newLevel.enabled = true;
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            Restart();
        }
        else
        {
            StartCoroutine(LoadLevel(nextSceneIndex));
        }

        
    }

    private void Restart()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("newLevel");

        yield return new WaitForSeconds(transistionTime);

        SceneManager.LoadScene(levelIndex);
    }
    
}
