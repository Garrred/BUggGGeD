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

        private BugBulletEmitter bugBulletEmitter;

        public void Awake()
        {
            bugBulletEmitter = transform.parent.GetChild(4).GetComponent<BugBulletEmitter>();
            SpriteRenderer[] spriteRenderer = transform.parent.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sr in spriteRenderer)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
            }
            hpBarUI.SetActive(true);
            hpDisplay = hpBarUI.GetComponent<Basics.HPDisplay>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
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
                if (transform.GetComponent<SpriteRenderer>() != null)
                    Flash(transform.parent);
                UpdateHP();
                if (health <= 0)
                {
                    isAlive = false;
                    EndBullet();
                    if (stage == 2)
                    {
                        isAlive = false;
                        Destroy(gameObject.transform.parent.gameObject);
                    }
                    else
                    {
                        bugBulletEmitter.UpdateBug(stage + 1);
                        stage++;
                        maxHealth = maxHealth * 1.25f;
                        Start();
                        hpDisplay.Start();
                        transform.parent.GetComponent<BossBehaviors>().StageChangeModification();
                    }
                }
            }
        }
        public void EndBullet()
        {
            transform.parent.GetChild(4).GetComponent<BugBulletEmitter>().enabled = false;
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
                transform.parent.GetChild(4).GetComponent<BugBulletEmitter>().enabled = true;
                currentBullet.transform.GetChild(currentBulletIndex).gameObject.SetActive(true);
                yield return new WaitForSeconds(20f);
                currentBullet.transform.GetChild(currentBulletIndex).gameObject.SetActive(false);
                currentBulletIndex = Mathf.Abs(currentBulletIndex - 1);
                yield return new WaitForSeconds(2f);
            }
        }
    }
}