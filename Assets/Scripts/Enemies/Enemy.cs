using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Enemy : EnemyBugs
    {
        public AudioSource audioSource;
        public AudioClip deathSound;
        public AudioClip attackSound;
        public float health;
        public float maxHealth;
        public int attackPower;
        public float stopDistance;
        public float timeBetweenAttacks;
        [HideInInspector]
        public float attackCoolDown = 0f;
        public float speed;
        // public int healthDropChance;
        // public GameObject healthDrop;
        public bool isInvincible = false;

        [HideInInspector]
        public Transform player;

        public GameObject[] possibleDrops;
        public int dropChance = 100;

        // Start is called before the first frame update
        public virtual void Start()
        {
            health = maxHealth;
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        public virtual void takeDamage(float damage)
        {
            if (!isInvincible)
            {
                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().Play();
                }
                health -= damage;
                if (transform.parent != null && transform.parent.parent != null)
                    Flash(transform.parent.parent);
                if (tag == "Enemy")
                {
                    Flash(transform);
                }
                if (health <= 0)
                {
                    DropItem();
                    // StartCoroutine(hpDisplay.FadeOut());
                    // if (Random.Range(0, 100) <= healthDropChance)
                    // {
                    //     Instantiate(healthDrop, transform.position, transform.rotation);
                    // }

                    Destroy(gameObject);
                }
            }
        }
        public void DropItem()
        {
            if (possibleDrops.Length > 0)
            {
                if (Random.Range(0, 100) <= dropChance)
                {
                    Instantiate(possibleDrops[Random.Range(0, possibleDrops.Length)], transform.position, Quaternion.identity);
                }
            }
        }
        public virtual void Flash(Transform materialLocation)
        {
            if (materialLocation.GetComponent<FlashOnHit>() != null)
            {
                transform.GetComponent<SpriteRenderer>().material.shader = materialLocation.GetComponent<FlashOnHit>().flashShader;
                StartCoroutine(ResetMaterial(materialLocation));
            }
        }
        public virtual IEnumerator ResetMaterial(Transform ob)
        {
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().material.shader = ob.GetComponent<FlashOnHit>().defaultShader;
        }

        // void OnDestroy()
        // {
        //     GameObject waveSpawner = GameObject.FindGameObjectWithTag("WaveSpawner");
        //     if (waveSpawner != null)
        //     {
        //         waveSpawner.GetComponent<WaveSpawner>().CountEnemies();
        //     }
        // }
    }
}