using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Basics
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed;
        public float rotationSpeed;
        public float slowRatio;

        public int health;
        public bool enableMovement = true;
        public bool isSticky = false;
        public bool hasBugNow = false;
        private Rigidbody2D rb;
        public Vector2 movementInput;
        private Vector2 playerRotation;
        private Attacks.Weapon weapon;

        private bool isInvincible = false;

        //private Animator animator;

        public GameObject hearts;
        // public Sprite fullHeart;
        //public Sprite emptyHeart;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            weapon = GetComponent<Attacks.Weapon>();
            //animator = GetComponent<Animator>();
            UpdateLife();
        }

        // Update is called once per frame
        void Update()
        {
            movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementInput *= slowRatio;
            }

            //if (movementInput != Vector2.zero) animator.SetBool("isRunning", true);
            //else animator.SetBool("isRunning", false);
        }

        private void FixedUpdate()
        {
            if (enableMovement)
            {
                if ((movementInput.x == 0 && movementInput.y != 0) || (movementInput.x != 0 && movementInput.y == 0))
                    rb.MovePosition(rb.position + movementInput * movementSpeed * Time.fixedDeltaTime);
                else
                    rb.MovePosition(rb.position + movementInput * movementSpeed * Time.fixedDeltaTime / Mathf.Sqrt(2));
                if (weapon != null && (!weapon.isShooting || weapon.rotationFreezed) && movementInput != Vector2.zero)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,
                        Quaternion.LookRotation(Vector3.forward, movementInput), rotationSpeed * Time.fixedDeltaTime);
                }
            }
        }

        public void Heal(int amount)
        {
            health += amount;
            UpdateLife();
        }
        // IEnumerator Blink()
        // {
        //     while (isInvincible)
        //     {
        //         foreach (Transform child in transform.GetChild(0))
        //         {
        //             child.GetComponent<SpriteRenderer>().color = Color.gray;
        //         }
        //         yield return new WaitForSeconds(0.5f);
        //         foreach (Transform child in transform.GetChild(0))
        //         {
        //             Debug.Log("aaaa aaaa");
        //             child.GetComponent<SpriteRenderer>().color = Color.white;
        //         }
        //     }
        // }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (isSticky)
            {
                other.transform.SetParent(transform);
            }
            else
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    takeDamage(1);
                    //UpdateLife();
                }
            }

        }

        public void takeDamage(int damage)
        {
            if (!isInvincible)
            {
                health -= damage;
                StartCoroutine(StartInvincibility());
            }
            if (health <= 0)
                Destroy(gameObject);
            UpdateLife();
        }

        public void UpdateLife()
        {
            if (hearts != null)
            {
                for (int i = 0; i < hearts.transform.childCount; i++)
                {
                    if (i < health)
                    {
                        hearts.transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {
                        hearts.transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
        }

        IEnumerator StartInvincibility()
        {
            isInvincible = true;
            // StartCoroutine(Blink());
            foreach (Transform child in transform.GetChild(0))
            {
                child.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            yield return new WaitForSeconds(3f);
            foreach (Transform child in transform.GetChild(0))
            {
                child.GetComponent<SpriteRenderer>().color = Color.white;
            }
            isInvincible = false;
        }
        //public void Heal(int healAmount)
        //{
        //    if (health + healAmount <= 5)
        //    {
        //        health += healAmount;
        //        UpdateLife();
        //    }
        //}
    }
}