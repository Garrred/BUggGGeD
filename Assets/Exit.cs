using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Animator animator;
    public float waitTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LoadMainMenu();
        }
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadScene(0));
    }
    IEnumerator LoadScene(int sceneIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneIndex);
    }

}
