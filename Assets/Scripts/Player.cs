using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int health;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    //private Animator animator;

    //public Image[] hearts;
    //public Sprite fullHeart;
    //public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        //UpdateLife();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //if (movementInput != Vector2.zero) animator.SetBool("isRunning", true);
        //else animator.SetBool("isRunning", false);
    }

    private void FixedUpdate()
    {
        if ((movementInput.x == 0 && movementInput.y != 0) ||
            (movementInput.x != 0 && movementInput.y == 0))
            rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
        else
            rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime / Mathf.Sqrt(2));
    }

    //public void takeDamage(int damage)
    //{
    //    health -= damage;
    //    if (health <= 0)
    //        Destroy(gameObject);
    //    UpdateLife();
    //}

    //public void UpdateLife()
    //{
    //    for (int i = 0; i < hearts.Length; i++)
    //    {
    //        if (i < health)
    //            hearts[i].sprite = fullHeart;
    //        else
    //            hearts[i].sprite = emptyHeart;
    //    }
    //}

    //public void Heal(int healAmount)
    //{
    //    if (health + healAmount <= 5)
    //    {
    //        health += healAmount;
    //        UpdateLife();
    //    }
    //}
}
