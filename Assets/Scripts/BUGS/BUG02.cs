using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG02 : BUGFrame
    {
        public GameObject cam;
        private Basics.CameraFollow cameraFollow;

        public override void BugStart()
        {
            cameraFollow = cam.GetComponent<Basics.CameraFollow>();
            cameraFollow.isSleeping = true;
        }

        public override void BugEnd()
        {
            cameraFollow.isSleeping = false;
        }
    }
}