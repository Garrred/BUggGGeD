using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{

    public class BUG07 : BUGFrame
    {
        public float movementSpeed = 12f;

        private bool bugActive;
        private Basics.Player player;
        private Attacks.Weapon weapon;
        private Rigidbody2D rb;
        private Transform playerObject;

        // Start is called before the first frame update
        void Start()
        {
            bugText = "Which One Is The Bullet?";
        }
        void FixedUpdate()
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                // rb.MovePosition(rb.position + (Vector2)collision.transform.forward * movementSpeed * Time.fixedDeltaTime);
                if (Input.GetMouseButton(0))
                {
                    playerObject.Translate(Vector3.up * movementSpeed * Time.deltaTime);
                }
            }
        }



        public override void BugStart()
        {
            remainingTime = lastingTime;
            playerObject = collision.gameObject.transform;
            rb = collision.GetComponent<Rigidbody2D>();
            player = collision.GetComponent<Basics.Player>();
            player.enableMovement = false;
            weapon = player.GetComponent<Attacks.Weapon>();

        }
        public override void BugEnd()
        {
            player.enableMovement = true;
        }
    }
}