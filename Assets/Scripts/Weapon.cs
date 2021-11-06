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
                Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                if (transform.rotation!= Quaternion.LookRotation(Vector3.forward, direction))
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, 
                    Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    if (Time.time >= shotTime)
                    {
                        Instantiate(bullet, shotPos.position, transform.rotation);
                        shotTime = Time.time + timeBetweenShots;
                    }

                }
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }
    }
}
