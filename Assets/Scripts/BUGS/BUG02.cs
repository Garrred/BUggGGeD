using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG02 : BUGFrame
    {
        public GameObject cam;
        private Basics.CameraFollow cameraFollow;


        public void Start()
        {
            bugText = "Camera: Player Position Not Found";
        }

        public override void BugStart()
        {
            cam = GameObject.FindGameObjectWithTag("Camera");
            remainingTime = lastingTime;
            cameraFollow = cam.GetComponent<Basics.CameraFollow>();
            cameraFollow.isSleeping = true;
        }

        public override void BugEnd()
        {
            cameraFollow.isSleeping = false;
        }
    }
}