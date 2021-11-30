using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG01 : BUGFrame
    {
        private Basics.Player player;
        public Sprite changedPlayerPrefab;
        public GameObject playerPrefabBullet;
        public GameObject playerBody;

        private GameObject originalBullet;

        public void Start()
        {
            bugText = "File Location Error";
        }
        public override void BugStart()
        {
            player = collision.GetComponent<Basics.Player>();
            originalBullet = player.gameObject.GetComponent<Attacks.Weapon>().bullet;
            player.GetComponent<Attacks.Weapon>().bullet = playerPrefabBullet;
            playerBody.SetActive(false);
            player.transform.Find("ShootPos").GetComponent<SpriteRenderer>().sprite = changedPlayerPrefab;
        }

        public override void BugEnd()
        {
            if (player != null)
            {
                player.GetComponent<Attacks.Weapon>().bullet = originalBullet;
                playerBody.SetActive(true);
                player.transform.Find("ShootPos").GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }
}