using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUG04 : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 10f;
    public float rotationTime = 3f;
    public bool isRotating = false;
    public Collision2D collision;

    private float remainingTime;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            collision.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * remainingTime);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.collision = collision;
            remainingTime = rotationTime;
            collision.gameObject.GetComponent<Player>().Dizzy(rotationTime);
        }
    }

}
