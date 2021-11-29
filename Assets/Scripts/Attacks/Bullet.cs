using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attacks
{
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

        protected void destorySpark()
        {
            Instantiate(spark, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (!(collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Enemy" ||
                collision.gameObject.tag == "BossCore"))
                return;
            if (collision.GetComponent<Enemies.Enemy>() != null)
                collision.GetComponent<Enemies.Enemy>().takeDamage(damage);
            else
                collision.transform.parent.GetComponent<Enemies.Enemy>().takeDamage(damage);
            Destroy(gameObject);
            destorySpark();
        }
        IEnumerator Flicker(Collider2D collision)
        {
            SpriteRenderer sprite = collision.GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                for (int i = 0; i < 20; i++)
                {
                    sprite.color += new Color(0.05f, 0.05f, 0.05f, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                for (int i = 0; i < 20; i++)
                {
                    sprite.color -= new Color(0.05f, 0.05f, 0.05f, 0);
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
    }
}