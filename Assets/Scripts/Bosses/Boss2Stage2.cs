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
    public float dashAttackDuration = 2f;
    public float dashedTime = 0f;
    public float dashSpeed = 15f;
    public float stopDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = timeBetweenAttacks;
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
            attackCooldown = UnityEngine.Random.Range(timeBetweenAttacks - 0.5f, timeBetweenAttacks + 0.5f);
            StartCoroutine(RotationAttack());
        }
    }

    IEnumerator RotationAttack()
    {
        // rotate to player
        Vector3 target = player.transform.position;
        Vector3 direction = (target - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        // this.transform.position = Vector3.MoveTowards(this.transform.position, target, 3f);
        while (dashedTime < dashAttackDuration)
        {
            if (player != null)
            {
                // if (Vector2.Distance(transform.position, player.position) > stopDistance)
                // {
                // transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                // }
                transform.position = Vector2.MoveTowards(transform.position, direction * 100, dashSpeed * Time.deltaTime);
            }
            transform.Rotate(0, 0, 1000 * Time.deltaTime);
            dashedTime += Time.fixedDeltaTime;
            yield return null;
        }
        dashedTime = 0f;
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

