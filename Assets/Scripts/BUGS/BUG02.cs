using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG02 : MonoBehaviour
    {
        public Basics.CameraFollow cameraFollow;
        public float sleepTime = 5f;

        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("OnTriggerEnter");
            if (collision.tag == "Player")
            {
                cameraFollow = GameObject.FindGameObjectWithTag("Camera").GetComponent<Basics.CameraFollow>();
                StartCoroutine(WaitForSleep(sleepTime));
            }
        }

        IEnumerator WaitForSleep(float sleepTime)
        {
            cameraFollow.isSleeping = true;
            yield return new WaitForSeconds(sleepTime);
            cameraFollow.isSleeping = false;
        }
    }
}