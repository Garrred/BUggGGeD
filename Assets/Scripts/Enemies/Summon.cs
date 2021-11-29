using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : Enemies.Enemy
{
    public float escapeDistance;

    private float summonCooldown;

    public GameObject minion;
    private Animator animator;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) < escapeDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime * 2);
            }
            else if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (attackCoolDown <= 0)
            {
                summon();
                attackCoolDown = timeBetweenAttacks;
            }
            attackCoolDown -= Time.deltaTime;
        }
    }

    public void summon()
    {
        attackCount++;
        if (player != null)
        {
            GameObject newMinion = Instantiate(minion, transform.position, transform.rotation);
            newMinion.transform.SetParent(transform);
        }
    }
}
