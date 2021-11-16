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
            isInvincible = true;
        }
        public override void takeDamage(float damage)
        {
            if (!isInvincible)
            {
                Debug.Log("Boss taking damage");
                health -= damage;
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