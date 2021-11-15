using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Basics
{
    public class HPDisplay : MonoBehaviour
    {
        public Image BossHPBar;
        public Enemies.Boss boss;

        // Update is called once per frame
        void Update()
        {
            BossHPBar.fillAmount = boss.health / boss.maxHealth;
            if (boss.health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}