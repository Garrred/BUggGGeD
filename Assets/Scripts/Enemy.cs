using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public int attackPower;
    public float timeBetweenAttack;
    public float speed;
    public int healthDropChance;
    public GameObject healthDrop;

    [HideInInspector]
    public Transform player;

    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (Random.Range(0, 100) <= healthDropChance)
            {
                Instantiate(healthDrop, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}