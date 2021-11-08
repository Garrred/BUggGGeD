using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{

    public class BUG06 : BUGFrame
    {
        void Start()
        {
            BUGNumber = "06";
            lastingTime = 5f;
        }

        // TODO: Delete the method in Player's script
        public override void BugStart()
        {
            collision.GetComponent<Attacks.Weapon>().buggedDirection = 
                Quaternion.Euler(0, 0, (Random.Range(0, 2) * 2 - 1) * 90);
        }

        public override void BugEnd()
        {
            collision.GetComponent<Attacks.Weapon>().buggedDirection = Quaternion.Euler(0, 0, 0);
        }
    }
}