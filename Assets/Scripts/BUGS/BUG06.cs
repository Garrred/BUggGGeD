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

        public override void BugEffect()
        {
            collision.GetComponent<Attacks.Weapon>().BugShootingDirection(lastingTime);
        }
    }
}