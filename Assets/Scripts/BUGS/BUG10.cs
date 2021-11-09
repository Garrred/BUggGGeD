using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUG10 : BUGFrame
{

    public override void BugStart()
    {
        collision.GetComponent<Basics.Player>().isSticky = true;
    }

    public override void BugEnd()
    {
        collision.GetComponent<Basics.Player>().isSticky = false;
    }
}
