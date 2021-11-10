using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public class GameControl : MonoBehaviour
    {
        public bool isPaused = false;
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

        private void Pause()
        {
            Time.timeScale = 0;
            isPaused = true;
        }

        private void Resume()
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}