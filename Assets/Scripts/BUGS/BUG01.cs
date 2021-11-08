using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG01 : BUGFrame
    {
        public Basics.Player player;
        public Sprite basicBullet;
        public GameObject playerBullet;
        public GameObject playerBody;

        private GameObject originalBullet;

        public override void BugStart()
        {
            player = collision.GetComponent<Basics.Player>();
            originalBullet = player.GetComponent<Attacks.Weapon>().bullet;
            player.GetComponent<Attacks.Weapon>().bullet = playerBullet;
            playerBody.SetActive(false);
            player.transform.Find("ShootPos").GetComponent<SpriteRenderer>().sprite = basicBullet;
        }

        public override void BugEnd()
        {
            player.GetComponent<Attacks.Weapon>().bullet = originalBullet;
            playerBody.SetActive(true);
            player.transform.Find("ShootPos").GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}