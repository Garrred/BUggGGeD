using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Stage2 : MonoBehaviour
{
    public float pushSpeed;
    public float knockedBackTime;

    private GameObject player;
    public float timeBetweenAttacks;
    private float attackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 100 * Time.deltaTime);
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        else
        {
            attackCooldown = timeBetweenAttacks;
            StartCoroutine(RotationAttack());
        }
    }

    IEnumerator RotationAttack()
    {
        // rotate to player
        Vector3 target = player.transform.position;
        target.y = this.transform.position.y;
        Vector3 direction = (target - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, q, Time.deltaTime * 10);
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Basics.Player>().enableMovement = false;
            Vector2 difference = other.gameObject.transform.position - this.transform.position;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = (difference * pushSpeed);

            StartCoroutine(Wait(other.gameObject, knockedBackTime));
        }
    }

    IEnumerator Wait(GameObject player, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.gameObject.GetComponent<Basics.Player>().enableMovement = true;
    }
}

