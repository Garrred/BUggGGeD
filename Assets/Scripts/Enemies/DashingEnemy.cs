using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingEnemy : Enemies.Enemy
{
    public float dashSpeed = 15f;
    public float dashAttackDuration = 2f;
    public float dashedTime = 0f;
    private bool isDashing = false;
    private bool spawningBug = false;
    // Update is called once per frame

    public override void Start()
    {
        base.Start();
        foreach (Transform child in transform)
        {
            child.GetComponent<BUGFrame>().bugEnabled = false;
        }
    }

    void Update()
    {
        this.transform.Rotate(0, 0, 300 * Time.deltaTime);
        if (player != null && !isDashing && !spawningBug)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (attackCoolDown <= 0)
            {
                if (attackCount >= attacksBeforeBug)
                {
                    StartCoroutine(BugDashAttack());
                }
                else
                {
                    StartCoroutine(DashAttack());
                }
            }
            attackCoolDown -= Time.deltaTime;

        }

    }


    IEnumerator DashAttack()
    {
        isDashing = true;
        attackCount++;
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
        attackCoolDown = timeBetweenAttacks;
    }

    IEnumerator BugDashAttack()
    {
        spawningBug = true;
        attackCount = 0;
        float chargingTime = stopTimeBeforeCasting;
        SpriteRenderer[] sprite = GetComponentsInChildren<SpriteRenderer>();
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                sprite[i].color = Color.Lerp(Color.white, Color.red, j / 20f);
                yield return new WaitForSeconds(0.02f);
            }
        }
        foreach (Transform child in transform)
        {
            child.GetComponent<BUGFrame>().bugEnabled = true;
        }
        StartCoroutine(DashAttack());
        while (isDashing)
        {
            yield return null;
        }
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                sprite[i].color = Color.Lerp(Color.red, Color.white, j / 20f);
                yield return new WaitForSeconds(0.02f);
            }
        }
        foreach (Transform child in transform)
        {
            child.GetComponent<BUGFrame>().bugEnabled = false;
        }
        spawningBug = false;
    }
}