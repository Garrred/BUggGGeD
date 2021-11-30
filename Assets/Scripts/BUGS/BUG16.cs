using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUG16 : BUGFrame
{
    private float originalRadius = 0.08300407f;
    private Vector3 originalSize = new Vector3(0.1660644f, 0.1660644f, 0.1660644f);
    // Start is called before the first frame update
    void Start()
    {
        bugText = "You Are Stung... Hurt Hurt Hurt";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void BugStart()
    {
        collision.GetComponent<CircleCollider2D>().radius = 0.3f;
        collision.transform.GetChild(1).GetChild(1).localScale = new Vector3(0.75f, 0.75f, 0.75f);
    }


    public override void BugEnd()
    {
        collision.GetComponent<CircleCollider2D>().radius = originalRadius;
        collision.transform.GetChild(1).GetChild(1).localScale = originalSize;
    }


}
