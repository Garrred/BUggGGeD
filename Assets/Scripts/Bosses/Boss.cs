using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Boss : Enemy
    {
        public GameObject hpBarUI;
        public GameObject next;
        public GameObject exit;

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
        public override void takeDamage(float damage)
        {
            if (!isInvincible)
            {
                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().Play();
                }
                health -= damage;
                if (transform.GetComponent<SpriteRenderer>() != null)
                    Flash(transform.parent);
                UpdateHP();
                if (health <= 0)
                {
                    isAlive = false;
                    EndBullet();
                    if (stage >= 2)
                    {
                        StartCoroutine(EndBoss());
                    }
                    else
                    {
                        stage++;
                        bugBulletEmitter.UpdateBug(stage);
                        transform.parent.GetComponent<BossBehaviors>().StageChangeModification();
                        Start();
                        hpDisplay.Start();
                    }
                }
            }
        }
        IEnumerator EndBoss()
        {
            stage++;
            transform.parent.GetComponent<BossBehaviors>().StageChangeModification();
            transform.parent.GetComponent<AudioSource>().Play();
            SpriteRenderer[] spriteRenderer = transform.parent.GetComponentsInChildren<SpriteRenderer>();

            float alpha = 1f;
            while (alpha > 0.01f)
            {
                alpha *= 0.9f;
                foreach (SpriteRenderer sr in spriteRenderer)
                {
                    int direction = Random.Range(0, 2) * 2 - 1;
                    transform.Translate(new Vector3(direction, direction, 0) * 10f * Time.deltaTime);
                    sr.color = new Color(1, 1, 1, alpha);
                    yield return null;
                }
            }
            hpBarUI.SetActive(false);
            yield return new WaitForSeconds(2f);
            next.SetActive(true);
            exit.SetActive(true);
            Destroy(gameObject.transform.parent.gameObject);
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

    }
}