using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
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
        SceneManager.LoadScene(1);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneNum);
    }
    public void SetLevel(int n)
    {

        Debug.Log("set level: " + n);
        sceneNum = n;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LevelMenu()
    {
        levelSelectionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        levelSelectionMenu.SetActive(false);
    }


}
