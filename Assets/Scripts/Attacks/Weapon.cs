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
        public bool rotationFreezed = false;

        public Quaternion buggedDirection = Quaternion.Euler(0, 0, 0);
        public Basics.GameControl gameManager;
        void Start()
        {
            shotTime = 0;
            isShooting = false;
            player = GetComponentInParent<Basics.Player>();
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Basics.GameControl>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!gameManager.isPaused && Input.GetMouseButton(0))
            {
                isShooting = true;
                if (Input.GetMouseButtonUp(0))
                {
                    isShooting = false;
                }

                if (isShooting)
                {
                    Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                    if (!rotationFreezed && transform.rotation != Quaternion.LookRotation(Vector3.forward, direction))
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                        Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.fixedDeltaTime);
                    }
                    else
                    {
                        if (Time.time >= shotTime)
                        {
                            Instantiate(bullet, shotPos.position, transform.rotation *buggedDirection);
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
}