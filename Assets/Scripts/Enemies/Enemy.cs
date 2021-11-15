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

        [HideInInspector]
        public Transform player;

        public Basics.HPDisplay hpDisplay;

        public void UpdateHP()
        {
            if (hpDisplay != null)
            {
                hpDisplay.UpdateHPBar();
            }
        }
        // Start is called before the first frame update
        public virtual void Start()
        {
            health = maxHealth;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void takeDamage(float damage)
        {
            health -= damage;
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
}