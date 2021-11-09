using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUG11 : BUGFrame
{
    public override void BugStart()
    {
        collision.transform.position += new Vector3(0f, 0f, 100f);
    }

    public override void BugEnd()
    {
        collision.transform.position += new Vector3(0f, 0f, -100f);
    }
}
