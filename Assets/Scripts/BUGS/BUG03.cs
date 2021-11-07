using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{

    public class BUG03 : MonoBehaviour
    {
        public ParticleSystem ps;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.tag = "FakePlayer";
                other.gameObject.GetComponent<Basics.Player>().enabled = false;
                other.gameObject.GetComponent<Attacks.Weapon>().enabled = false;
                transform.Translate(new Vector3(0, 10f, 0));
                Instantiate(ps, transform.position, Quaternion.identity);
                GameObject.FindGameObjectWithTag("Camera").GetComponent<Basics.CameraFollow>().ResetFollow();
                Destroy(gameObject);
            }
        }
    }
}