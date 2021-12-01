using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startButtonClick;
    public AudioClip quitButtonClick;
    public AudioClip selectButtonClick;
    public AudioClip stageClick;

    public float waitTime = 2f;
    public GameObject levelSelectionMenu;
    public GameObject mainMenu;

    private int sceneNum = 1; //0 just for now

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void LoadFirstLevel()
    {
        audioSource.PlayOneShot(startButtonClick);
        SceneManager.LoadScene(1);
    }

    public void LoadLevel()
    {
        audioSource.PlayOneShot(startButtonClick);
        SceneManager.LoadScene(sceneNum);
    }
    public void SetLevel(int n)
    {
        audioSource.PlayOneShot(stageClick);
        sceneNum = n;
    }

    public void Quit()
    {
        audioSource.PlayOneShot(quitButtonClick);
        Application.Quit();
    }

    public void LevelMenu()
    {
        audioSource.PlayOneShot(selectButtonClick);
        levelSelectionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void MainMenu()
    {
        audioSource.PlayOneShot(selectButtonClick);
        mainMenu.SetActive(true);
        levelSelectionMenu.SetActive(false);
    }


}
