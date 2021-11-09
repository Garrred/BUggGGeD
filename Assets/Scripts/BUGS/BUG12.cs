using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUG12 : BUGFrame
{
    public override void BugStart()
    {
        collision.GetComponent<Attacks.Weapon>().rotationFreezed = true;
    }

    public override void BugEnd()
    {
        collision.GetComponent<Attacks.Weapon>().rotationFreezed = false;
    }

}
