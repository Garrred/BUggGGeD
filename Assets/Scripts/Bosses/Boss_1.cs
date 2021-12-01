using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : BossBehaviors
{

    public Transform innerShield;
    public Transform outerShield;
    public Enemies.Boss boss;
    public float pushSpeed;
    public float knockedBackTime;
    public GameObject movePoints;
    public float speed;

    private float step;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        innerShield = this.transform.GetChild(1);
        outerShield = this.transform.GetChild(2);
        boss = transform.GetChild(0).GetComponent<Enemies.Boss>();

        for (int i = 0; i < innerShield.childCount; i++)
        {
            innerShield.GetChild(i).gameObject.GetComponent<Enemies.Enemy>().isInvincible = true;
        }

        if (movePoints != null)
        {
            target = movePoints.transform.GetChild(Random.Range(0, 4));
        }
    }

    public override void StageChangeModification()
    {
        if (boss.stage >= 3)
        {
            return;
        }
        boss.maxHealth = boss.maxHealth * 1.5f;
        // disable the inner shield's invincibility
        if (boss.stage == 1)
        {
            for (int i = 0; i < innerShield.childCount; i++)
            {
                innerShield.GetChild(i).gameObject.GetComponent<Enemies.Enemy>().isInvincible = false;
            }
        }
        TakeOffShield(boss.stage);
    }

    void TakeOffShield(int stage)
    {
        GameObject currentShield = transform.GetChild(3 - stage).gameObject;
        StartCoroutine(FadeOffShield(currentShield));
    }

    IEnumerator FadeOffShield(GameObject currentShield)
    {
        float alpha = 1f;
        while (alpha > 0.01f)
        {
            alpha *= 0.9f;
            foreach (Transform child in currentShield.transform)
            {
                int direction = Random.Range(0, 2) * 2 - 1;
                child.Translate(new Vector3(direction, direction, 0) * 10f * Time.deltaTime);
                child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                yield return null;
            }
        }
        currentShield.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < innerShield.childCount; i++)
        {
            innerShield.GetChild(i).transform.Rotate(0, 0, 50 * Time.deltaTime);
        }
        for (int i = 0; i < outerShield.childCount; i++)
        {
            outerShield.GetChild(i).transform.Rotate(0, 0, -50 * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if ((transform.position - target.position).magnitude < 1)
            {
                //rendomly generate next target
                target = movePoints.transform.GetChild(Random.Range(0, 3));
            }
            step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
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
