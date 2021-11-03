using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPos;
    public float timeBetweenShots;

    private float shotTime;
    private bool isShooting;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isShooting = true;
            if (Input.GetMouseButtonUp(0))
            {
                isShooting = false;
            }

            if (isShooting)
            {
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                transform.rotation = rotation;
            }

            if (Time.time >= shotTime)
            {
                Instantiate(bullet, shotPos.position, transform.rotation);
                shotTime = Time.time + timeBetweenShots;
            }
        }

    }
}
