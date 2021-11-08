using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attacks
{
    public class Weapon : MonoBehaviour
    {
        public GameObject bullet;
        public Transform shotPos;
        public float timeBetweenShots;
        public float rotationSpeed;
        public float BugNum;

        private float shotTime;
        public bool isShooting;
        private Basics.Player player;
        private Quaternion rotation;

        public Quaternion buggedDirection = Quaternion.Euler(0, 0, 0);
        void Start()
        {
            shotTime = 0;
            isShooting = false;
            player = GetComponentInParent<Basics.Player>();

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
                    if (transform.rotation != Quaternion.LookRotation(Vector3.forward, direction))
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                        Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.fixedDeltaTime);
                    }
                    else
                    {
                        if (Time.time >= shotTime)
                        {
                            if (BugNum == 7)
                            {
                                this.transform.Translate(Vector2.up * 10 * Time.deltaTime);
                            }
                            else
                            {
                                Instantiate(bullet, shotPos.position, transform.rotation *buggedDirection);
                                shotTime = Time.time + timeBetweenShots;
                            }
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
}