using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{

    public class BUG03_ParticleSys : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "FakePlayer")
            {
                collision.gameObject.GetComponent<Basics.Player>().enabled = true;
                collision.gameObject.GetComponent<Attacks.Weapon>().enabled = true;
                collision.gameObject.tag = "Player";
                Destroy(gameObject);
            }
        }
        void OnDestroy()
        {
            GameObject.FindGameObjectWithTag("Camera").GetComponent<Basics.CameraFollow>().ResetFollow();
        }
    }
}