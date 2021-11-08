using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{

    public class BUG05 : BUGFrame
    {
        private Rigidbody2D bulletRB;
        private Rigidbody2D playerRB;

        void Start()
        {
            BUGNumber = "05";
            lastingTime = 5f;
        }

        public override void BugStart()
        {
            playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRB.gravityScale = 10f;
            bulletRB = collision.gameObject.GetComponent<Attacks.Weapon>().bullet.GetComponent<Rigidbody2D>();
            bulletRB.gravityScale = 1f;
        }

        public override void BugEnd()
        {
            bulletRB.gravityScale = 0f;
            playerRB.gravityScale = 0f;
        }
    }
}