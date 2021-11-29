using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{

    public class BUG08 : BUGFrame
    {
        public float movementSpeed = 10;
        public Basics.Player player;
        public GameObject cam;
        private Vector2 movementInput;
        private Rigidbody2D rb;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Basics.Player>();
            player.enableMovement = false;
            lastingTime = 5f;
            rb = this.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;


        }

        private void FixedUpdate()
        {
           movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            //this.transform.Translate(movementInput * movementSpeed * Time.deltaTime);
            //rb.AddForce(movementInput * movementSpeed * Time.deltaTime);
            rb.MovePosition(rb.position + movementInput * movementSpeed * Time.fixedDeltaTime);

        }

        // TODO: Delete the method in Player's script
        public override void BugStart(){
            cam.GetComponent<Basics.CameraFollow>().isSleeping = true;
        }

        public override void BugEnd(){}
    }
}