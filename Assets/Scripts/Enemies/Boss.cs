using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Boss : Enemy
    {
        public GameObject hpBarUI;
        private Basics.HPDisplay hpDisplay;
        private GameObject currentBullet;
        private int currentBulletIndex;
        private bool isAlive;

        public int stage = 0;

        public void Awake()
        {
            hpBarUI.SetActive(true);
        }
        public void UpdateHP()
        {
            if (hpDisplay != null)
            {
                hpDisplay.UpdateHPBar();
            }
        }
        public override void Start()
        {
            isAlive = true;
            health = maxHealth;
            hpDisplay = hpBarUI.GetComponent<Basics.HPDisplay>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            isInvincible = true;
            StartCoroutine(StartBulletEmission());
        }

        public void UpdateShootingPos()
        {
            if (currentBullet != null)
            {
                currentBullet.transform.GetChild(currentBulletIndex).position = transform.position;
            }
        }
        public void StartBullet()
        {
            currentBullet = transform.GetChild(stage).gameObject;
            StartCoroutine(ChangeBulletPattern());
        }
        public override void takeDamage(float damage)
        {
            if (!isInvincible)
            {
                health -= damage;
                UpdateHP();
                if (health <= 0)
                {
                    isAlive = false;
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
                    transform.parent.GetComponent<BossBehaviors>().StageChangeModification();
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
        
        public IEnumerator ChangeBulletPattern()
        {
            while (isAlive)
            {
                UpdateShootingPos();
                currentBullet.transform.GetChild(currentBulletIndex).gameObject.SetActive(true);
                yield return new WaitForSeconds(20f);
                currentBullet.transform.GetChild(currentBulletIndex).gameObject.SetActive(false);
                currentBulletIndex = Mathf.Abs(currentBulletIndex - 1);
                yield return new WaitForSeconds(2f);
            }
        }
    }
}