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
    private bool isDashing = false;
    public int count = 0;

    public bool splitedIntoFour = false;
    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = timeBetweenAttacks;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!splitedIntoFour)
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
    }

    IEnumerator RotationAttack()
    {
        gameObject.GetComponent<BulletPro.BulletEmitter>().enabled = false;
        transform.GetChild(2).gameObject.SetActive(false);
        isDashing = true;
        // rotate to player
        Vector3 target = player.transform.position;
        yield return new WaitForSeconds(0.5f);
        Vector3 direction = (target - this.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Quaternion targetRotation = transform.rotation;
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
            // targetRotation *= Quaternion.AngleAxis(10, Vector3.forward);
            // transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
            // transform.Rotate(0, 0, 100 * Time.deltaTime + 4000 * Time.deltaTime * Mathf.Pow((dashAttackDuration * 0.5f - Mathf.Abs(0.5f * dashAttackDuration - dashedTime)), 2) / dashAttackDuration);
            transform.Rotate(0, 0, 1000 * Time.deltaTime);
            dashedTime += Time.fixedDeltaTime;
            yield return null;
        }
        dashedTime = 0f;
        isDashing = false;
        if (count == 0)
        {
            gameObject.GetComponent<BulletPro.BulletEmitter>().enabled = true;
            count++;
        }
        else
        {
            transform.GetChild(2).gameObject.SetActive(true);
            count--;
        }
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

