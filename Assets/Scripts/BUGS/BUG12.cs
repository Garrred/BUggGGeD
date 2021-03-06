using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG12 : BUGFrame
    {

        void Start()
        {
            bugText = "Freeze(this.bullet.rotation)";
        }
        public override void BugStart()
        {
            collision.GetComponent<Attacks.Weapon>().rotationFreezed = true;
        }

        public override void BugEnd()
        {
            collision.GetComponent<Attacks.Weapon>().rotationFreezed = false;
        }

    }
}