using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG10 : BUGFrame
    {

        void Start()
        {
            bugText = "There Are Merge Conflicts In Remote Repository";
        }
        public override void BugStart()
        {
            collision.GetComponent<Basics.Player>().isSticky = true;
        }

        public override void BugEnd()
        {
            collision.GetComponent<Basics.Player>().isSticky = false;
        }
    }
}