using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemies.Enemy
{
    public float stopDistance;
    public float attackSpeed;

    private float attackCoolDown;


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= attackCoolDown)
                {
                    StartCoroutine(Attack());
                    attackCoolDown = Time.time + timeBetweenAttack;
                }
            }
        }
    }

    IEnumerator Attack()
    {
        player.GetComponent<Basics.Player>().takeDamage(attackPower);

        Vector2 currentPos = transform.position;
        Vector2 targetPos = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float inter = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(currentPos, targetPos, inter);
            yield return null;
        }
    }

}