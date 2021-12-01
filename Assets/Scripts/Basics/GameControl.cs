using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Basics
{
    public class GameControl : MonoBehaviour
    {
        public float waitTime = 2f;
        public bool isPaused = false;
        public GameObject pauseMenu;
        public GameObject pauseButton;

        void Awake()
        {
            Time.timeScale = 1f;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Pause()
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
        }

        public void Resume()
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
        }
        public void Quit()
        {
            SceneManager.LoadScene(0);
        }

        IEnumerator LoadScene(int sceneIndex)
        {
            //Debug.Log("haha");
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(sceneIndex);
            //yield return null;
        }
    }
}