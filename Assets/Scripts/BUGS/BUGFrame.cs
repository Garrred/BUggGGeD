using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUGFrame : MonoBehaviour
{
    [HideInInspector]
    public string BUGNumber;
    public float lastingTime = 5f;
    public float remainingTime = -10f;
    public bool bugEnabled = true;


    [HideInInspector]
    public Collider2D collision;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (bugEnabled && other.gameObject.tag == "Player")
        {
            remainingTime = lastingTime;
            this.collision = other;
            BugStart();
            Invoke("BugEnd", remainingTime);
        }
    }

    public virtual void BugStart() 
    {
        Debug.Log("This bug is not implemented");
    }
    public virtual void BugEnd()
    {
        Debug.Log("This bug is not implemented");
    }
}
