using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUGFrame : MonoBehaviour
{
    public string BUGNumber;
    public float lastingTime = 5f;
    public float remainingTime = -10f;

    public Collider2D collision;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.collision = other;
            remainingTime = lastingTime;
            BugStart();
            Invoke("EndBug", remainingTime);
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
