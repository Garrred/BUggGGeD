using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class RangedEnemy : Enemy
    {
        public float stopDistance;
        // private Animator animator;
        private float shootCooldown;
        public GameObject bullet;

        public override void Start()
        {
            base.Start();
            shootCooldown = 1f;
            // animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (shootCooldown > 0)
            {
                shootCooldown -= Time.deltaTime;
            }
            else
            {
                shootCooldown = timeBetweenAttack;
                Attack();
            }

            if (player != null)
            {
                if (Vector2.Distance(transform.position, player.position) > stopDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
                else
                {
                    if (Time.time >= shootCooldown)
                    {
                        shootCooldown = Time.time + timeBetweenAttack;
                        // animator.SetBool("isAttacking", true);
                    }
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

                Instantiate(bullet, transform.position, rotation);
                // StartCoroutine(attacking());
                // animator.SetBool("isAttacking", false);
            }
        }

        // IEnumerator attacking()
        // {
        //     yield return new WaitForSeconds(
        //         animator.GetCurrentAnimatorStateInfo(0).length +
        //         animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        // }
    }
}