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
        }
        public override void takeDamage(float damage)
        {
            if (!isInvincible)
            {
                health -= damage;
                UpdateHP();
                if (health <= 0)
                {
                    if (stage == 2)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        maxHealth = maxHealth * 1.25f;
                        base.Start();
                        hpDisplay.Start();
                        stage++;
                    }
                }
            }
        }
    }
}