using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{

    public class BUG03 : BUGFrame
    {
        public ParticleSystem ps;
        public Basics.CameraFollow cam;

        public void Start()
        {
            bugText = "Null Pointer Exception";
        }
        public override void BugStart()
        {
            collision.gameObject.tag = "FakePlayer";
            collision.gameObject.GetComponent<Basics.Player>().enabled = false;
            // collision.GetComponent<Attacks.Weapon>().enabled = false;
            cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<Basics.CameraFollow>();

            transform.Translate(new Vector3(0, 10f, 0));
            Instantiate(ps, transform.position, Quaternion.identity);
            StartCoroutine(ResetFollow());
        }

        IEnumerator ResetFollow()
        {
            yield return new WaitForSeconds(0.5f);
            cam.ResetFollow();
        }

        public override void BugEnd()
        {
            // behavior is done in the particle system
        }
    }
}