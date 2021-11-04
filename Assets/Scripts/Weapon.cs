using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPos;
    public float timeBetweenShots;
    public float rotationSpeed;

    private float shotTime;
    public bool isShooting;
    private Player player;
    private Quaternion rotation;

    void Start()
    {
        shotTime = 0;
        isShooting = false;
        player = GetComponentInParent<Player>();
    }

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
                rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                Debug.Log(rotation);
                Debug.Log(transform.rotation);


                if (transform.rotation != rotation)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.fixedDeltaTime);
                }
            }

            if (Time.time >= shotTime)
            {
                Instantiate(bullet, shotPos.position, transform.rotation);
                shotTime = Time.time + timeBetweenShots;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }
    }
}
