using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    public float waitTime = 2f;

    public void LoadNewScene(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }
    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneIndex);
        animator.SetTrigger("End");
    }
    public void QuitToMainMenu()
    {
        StartCoroutine(LoadScene(0));
    }
}
