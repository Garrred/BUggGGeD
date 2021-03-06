using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG04 : BUGFrame
    {
        public float rotationSpeed = 10f;
        public Basics.Player player;
        private Attacks.Weapon weapon;

        void Start()
        {
            lastingTime = 3f;
            bugText = "Player.Rotate(Vector3.forward)";
        }
        void Update()
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                collision.transform.Rotate(Vector3.forward * rotationSpeed * remainingTime);
            }
        }

        public override void BugStart()
        {
            player = collision.GetComponent<Basics.Player>();
            weapon = player.GetComponent<Attacks.Weapon>();

            player.enableMovement = false;
            weapon.enabled = false;

            remainingTime = lastingTime;
        }

        public override void BugEnd()
        {
            player.enableMovement = true;
            weapon.enabled = true;
        }
    }
}