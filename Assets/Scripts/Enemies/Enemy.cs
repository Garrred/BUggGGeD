using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        [HideInInspector]
        public float health;
        public float maxHealth;
        public int attackPower;
        public float timeBetweenAttack;
        public float speed;
        // public int healthDropChance;
        // public GameObject healthDrop;
        public bool isInvincible = false;

        [HideInInspector]
        public Transform player;

        // Start is called before the first frame update
        public virtual void Start()
        {
            health = maxHealth;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public virtual void takeDamage(float damage)
        {
            if (!isInvincible)
            {
                health -= damage;
                Flash(transform.parent.parent);
                if (health <= 0)
                {
                    // StartCoroutine(hpDisplay.FadeOut());
                    // if (Random.Range(0, 100) <= healthDropChance)
                    // {
                    //     Instantiate(healthDrop, transform.position, transform.rotation);
                    // }

                    Destroy(gameObject);
                }
            }
        }

        public void Flash(Transform ob)
        {
            GetComponent<SpriteRenderer>().material.shader = ob.GetComponent<FlashOnHit>().flashShader;
            StartCoroutine(ResetMaterial(ob));
        }
        public IEnumerator ResetMaterial(Transform ob)
        {
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().material.shader = ob.GetComponent<FlashOnHit>().defaultShader;
        }
    }
}