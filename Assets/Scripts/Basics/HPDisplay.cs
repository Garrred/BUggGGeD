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
        public CanvasGroup canvasGroup;

        public void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            BossHPBar.fillAmount = 0;
            StartCoroutine(FillBar());
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            if (boss.health <= 0)
            {
                if (canvasGroup.alpha > 0)
                    canvasGroup.alpha -= Time.fixedDeltaTime;
            }
        }

        IEnumerator FillBar()
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.fixedDeltaTime;
                yield return null;
            }
            while (BossHPBar.fillAmount < 1)
            {
                BossHPBar.fillAmount += Time.fixedDeltaTime * 0.3f;
                yield return null;
            }
            boss.isInvincible = false;
        }

        public void UpdateHPBar()
        {
            BossHPBar.fillAmount = boss.health / boss.maxHealth;
        }
    }
}