using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Boss : Enemy
    {
        int stage = 0;
        public override void Start()
        {
            health = maxHealth;
            player = GameObject.FindGameObjectWithTag("Player").transform;
            isInvincible = true;
            StartBullet();
        }

        public void StartBullet()
        {
            if (stage == 0)
            {
                transform.Find("Stage1Bullet").gameObject.SetActive(true);
            }
            else if (stage == 1)
            {
                transform.Find("Stage2Bullet").gameObject.SetActive(true);
            }
            else 
            {
                transform.Find("Stage3Bullet").gameObject.SetActive(true);
            }
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
            if (stage == 0)
            {
                transform.Find("Stage1Bullet").gameObject.SetActive(false);
            }
            else if (stage == 1)
            {
                transform.Find("Stage2Bullet").gameObject.SetActive(false);
            }
            else
            {
                transform.Find("Stage3Bullet").gameObject.SetActive(false);
            }
        }
    }
}