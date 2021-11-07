using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{

    public class BUG05 : MonoBehaviour
    {
        private Rigidbody2D bulletRB;
        private Rigidbody2D playerRB;
        public float gravityTime = 3f;
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
                playerRB = other.gameObject.GetComponent<Rigidbody2D>();
                playerRB.gravityScale = 10f;
                bulletRB = other.gameObject.GetComponent<Attacks.Weapon>().bullet.GetComponent<Rigidbody2D>();
                bulletRB.gravityScale = 1f;
                StartCoroutine(Wait(gravityTime));
            }
        }
        IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
            bulletRB.gravityScale = 0f;
            playerRB.gravityScale = 0f;
        }
    }
}