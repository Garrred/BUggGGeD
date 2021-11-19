using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{

    public Transform innerShield;
    public Transform outerShield;
    public float pushSpeed;
    public float knockedBackTime;
    // Start is called before the first frame update
    void Start()
    {

        innerShield = this.transform.GetChild(1);
        outerShield = this.transform.GetChild(2);
    }

    // Update is called once per frame
    void Update()
    {
        innerShield.Rotate(0, 0, 50 * Time.deltaTime);
        outerShield.Rotate(0, 0, -50 * Time.deltaTime);



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("haha");
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
