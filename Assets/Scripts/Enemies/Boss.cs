using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Boss : Enemy
    {
        public Basics.HPDisplay hpDisplay;
        private GameObject currentBullet;

        int stage = 0;
        public void UpdateHP()
        {
            if (hpDisplay != null)
            {
                hpDisplay.UpdateHPBar();
            }
        }
        public override void Start()
        {
            health = maxHealth;
            hpDisplay = GameObject.FindGameObjectWithTag("HPDisplay").GetComponent<Basics.HPDisplay>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            isInvincible = true;
            StartCoroutine(StartBulletEmission());
        }

        public void UpdateShootingPos()
        {
            if (currentBullet != null)
            {
                currentBullet.transform.position = transform.position;
            }
        }
        public void StartBullet()
        {
            currentBullet = transform.Find("Stage" + (stage + 1) + "Bullet").gameObject;
            UpdateShootingPos();
            currentBullet.SetActive(true);
        }
        public override void takeDamage(float damage)
        {
            if (!isInvincible)
            {
                health -= damage;
                UpdateHP();
                if (health <= 0)
                {
                    EndBullet();
                    if (stage == 2)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        stage++;
                        maxHealth = maxHealth * 1.25f;
                        Start();
                        hpDisplay.Start();
                    }
                }
            }
        }
        public void EndBullet()
        {
            currentBullet.SetActive(false);
        }
        public IEnumerator StartBulletEmission()
        {
            yield return new WaitForSeconds(2f);
            StartBullet();
        }
    }
}