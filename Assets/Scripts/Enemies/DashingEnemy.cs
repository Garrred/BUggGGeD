using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingEnemy : Enemies.Enemy
{
    public float dashSpeed = 15f;
    public float dashAttackDuration = 2f;
    public float dashedTime = 0f;
    private bool isDashing = false;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 300 * Time.deltaTime);
        if (player != null)
        {
            if (!isDashing && Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (attackCoolDown <= 0)
            {
                isDashing = true;
                StartCoroutine(DashAttack());
                attackCoolDown = timeBetweenAttacks;
            }
            attackCoolDown -= Time.deltaTime;

        }

    }


    IEnumerator DashAttack()
    {
        Vector3 target = player.transform.position;
        yield return new WaitForSeconds(0.5f);
        Vector3 direction = (target - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        while (dashedTime < dashAttackDuration)
        {
            transform.position = Vector2.MoveTowards(transform.position, direction * 100, dashSpeed * Time.deltaTime);

            transform.Rotate(0, 0, 1000 * Time.deltaTime);
            dashedTime += Time.fixedDeltaTime;
            yield return null;
        }
        dashedTime = 0f;
        isDashing = false;
    }
}