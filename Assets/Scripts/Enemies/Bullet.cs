using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Attacks.Bullet
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Basics.Player>().isSticky)
            {
                StickOntoPlayer(collision);
            }
            else
            {
                collision.GetComponent<Basics.Player>().takeDamage((int)damage);
                // destorySpark();
            }
        }
        if (collision.transform.parent != null && collision.transform.parent.tag == "Player")
        {
            if (collision.GetComponentInParent<Basics.Player>().isSticky)
            {
                StickOntoPlayer(collision);
            }
        }
    }

    private void StickOntoPlayer(Collider2D collision)
    {
        bulletSpeed = 0f;
        bulletLifeTime = 100f;
        transform.SetParent(collision.transform);
    }
}