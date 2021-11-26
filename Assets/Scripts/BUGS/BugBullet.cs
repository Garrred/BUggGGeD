using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBullet : MonoBehaviour
{
    public float timeBetweenShots = 1f;
    private float timeSinceLastShot = 0f;

    public GameObject bugBulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastShot > timeBetweenShots)
        {
            timeSinceLastShot = 1f;
            Shoot();
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }

    void Shoot()
    {
        timeSinceLastShot = 0f;
        transform.Rotate(0, 0, 30f);
        // shoot bullet in four directions
        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = Instantiate(bugBulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Enemies.Bullet>().transform.rotation = Quaternion.Euler(0, 0, (i * 90) + transform.rotation.eulerAngles.z);
        }
    }
}
