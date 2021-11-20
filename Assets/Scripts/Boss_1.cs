using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{

    public Transform innerShield;
    public Transform outerShield;
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

        if (movePoints != null)
        {
            target = movePoints.transform.GetChild(Random.Range(0, 4));
        }
    }

    // Update is called once per frame
    void Update()
    {
        innerShield.Rotate(0, 0, 50 * Time.deltaTime);
        outerShield.Rotate(0, 0, -50 * Time.deltaTime);

        

    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if ((transform.position - target.position).magnitude < 17)
            {
                //rendomly generate next target
                target = movePoints.transform.GetChild(Random.Range(0, 3));
            }
            else
            {
                Debug.Log("not equal: " + (transform.position - target.position).magnitude);
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
