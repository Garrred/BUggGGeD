using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletLifeTime;

    public GameObject spark;
    public float damage; 


    // Start is called before the first frame update
    //void Start()
    //{
    //    Invoke("destorySpark", bulletLifeTime);
    //}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

        bulletLifeTime -= Time.deltaTime;
        if (bulletLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    //protected void destorySpark()
    //{
    //    Instantiate(spark, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().takeDamage(damage);
            //destorySpark();
        }
    }
}