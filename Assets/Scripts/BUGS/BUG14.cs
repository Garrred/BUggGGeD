using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG14 : BUGFrame
    {
        private float freezeTime = 1f;
        private Transform player;
        private Basics.Player playerScript;
        private Transform enemies;
        public GameObject playerBullets;
        private Attacks.Weapon weaponScript;
        // Start is called before the first frame update
        void Start()
        {
            bugText = "Ping: 999ms";
        }

        // Update is called once per frame
        void Update()
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                if (freezeTime > 0) 
                {
                    freezeTime -= Time.deltaTime;
                    if (freezeTime <= 0)
                    {
                        Freeze();
                        freezeTime = Random.Range(0.2f, 0.5f);
                        StartCoroutine(Melt());
                    }
                }
            }
        }

        public override void BugStart()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerScript = player.GetComponent<Basics.Player>();
            // enemies = GameObject.FindGameObjectWithTag("WaveSpawner").transform.GetChild(0);
            playerBullets = GameObject.FindGameObjectWithTag("PlayerBullets");
            weaponScript = collision.GetComponent<Attacks.Weapon>();
        }
        public override void BugEnd()
        {
        }
        public void Freeze()
        {
            weaponScript.rotationFreezed = true;
            Time.timeScale = 0f;
        }
        IEnumerator Melt()
        {
            yield return new WaitForSecondsRealtime(freezeTime);
            weaponScript.rotationFreezed = false;
            Time.timeScale = 1f;
            player.position += new Vector3(playerScript.movementInput.x, playerScript.movementInput.y, 0);
            foreach (Transform bullet in playerBullets.transform)
            {
                bullet.Translate(Vector3.up * bullet.GetComponent<Attacks.Bullet>().bulletSpeed * freezeTime);
            }
            // enemies.Translate(Vector3.up * 2 * freezeTime);
        }
    }
}