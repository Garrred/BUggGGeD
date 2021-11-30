using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG09 : BUGFrame
    {
        private GameObject bullet;
        private float originalSpeed;

        void Start()
        {
            bugText = "Bullet Script Not Found";
        }
        public override void BugStart()
        {
            bullet = collision.GetComponent<Attacks.Weapon>().bullet;
            originalSpeed = bullet.GetComponent<Attacks.Bullet>().bulletSpeed;
            bullet.GetComponent<Attacks.Bullet>().bulletSpeed = 0f;
            bullet.GetComponent<CapsuleCollider2D>().isTrigger = false;
        }

        public override void BugEnd()
        {
            bullet.GetComponent<Attacks.Bullet>().bulletSpeed = originalSpeed;
            bullet.GetComponent<CapsuleCollider2D>().isTrigger = true;
        }
    }
}