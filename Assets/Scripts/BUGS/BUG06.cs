using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{

    public class BUG06 : MonoBehaviour
    {
        public float buggedAngleTime = 5f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<Attacks.Weapon>().BugShootingDirection(buggedAngleTime);
            }
        }

    }
}