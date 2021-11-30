using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class RangedEnemy : Enemy
    {
        // private Animator animator;
        public GameObject bullet;
        public GameObject bugBullet;
        public GameObject bugBulletSpark;
        public bool isCastingBug = false;

        public override void Start()
        {
            base.Start();
            // animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!isCastingBug)
            {

                if (attackCoolDown > 0)
                {
                    attackCoolDown -= Time.fixedDeltaTime;
                }
                else
                {
                    attackCoolDown = timeBetweenAttacks;
                    Attack();
                }

                if (player != null)
                {
                    if (Vector2.Distance(transform.position, player.position) > stopDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                    }
                    else if (attackCoolDown <= 0)
                    {
                        Attack();
                        attackCoolDown = timeBetweenAttacks;
                    }
                    attackCoolDown -= Time.fixedDeltaTime;
                }
            }

        }

        public void Attack()
        {
            if (player != null)
            {
                Vector2 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                if (attackCount >= attacksBeforeBug)
                {
                    StartCoroutine(BugAttack(rotation));
                }
                else
                {
                    Instantiate(bullet, transform.position, rotation);
                    attackCount++;
                }
                // StartCoroutine(attacking());
                // animator.SetBool("isAttacking", false);
            }
        }

        public IEnumerator BugAttack(Quaternion rotation)
        {
            isCastingBug = true;
            attackCount = 0;
            yield return new WaitForSeconds(1f);
            Instantiate(bugBullet, transform.position, rotation);
            GameObject spark = Instantiate(bugBulletSpark, transform.position, rotation);
            yield return new WaitForSeconds(2f);
            isCastingBug = false;
        }

        // IEnumerator attacking()
        // {
        //     yield return new WaitForSeconds(
        //         animator.GetCurrentAnimatorStateInfo(0).length +
        //         animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        // }
    }
}