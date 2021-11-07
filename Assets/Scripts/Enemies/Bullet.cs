using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Attacks.Bullet
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Basics.Player>().takeDamage((int)damage);
            // destorySpark();
        }
    }
}