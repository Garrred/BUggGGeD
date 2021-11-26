using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBulletEmitter : MonoBehaviour
{
    public float timeBetweenShots = 1f;
    private float timeSinceLastShot = 0f;
    public BUGFrame[] bugs;
    public GameObject bugBulletPrefab;
    private BUGFrame currentBug;

    void Start()
    {
        currentBug = bugs[0];
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
            bullet.AddComponent(currentBug.GetType());
            bullet.GetComponent<Enemies.Bullet>().transform.rotation = Quaternion.Euler(0, 0, (i * 90) + transform.rotation.eulerAngles.z);
        }
    }

    public void UpdateBug(int stage)
    {
        currentBug = bugs[stage];
    }
}
