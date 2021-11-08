using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUGFrame : MonoBehaviour
{
    public string BUGNumber;
    public float lastingTime;
    private float remainingTime = -10f;

    public Collider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = lastingTime;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.collision = other;
            BugEffect();
            Invoke("EndBug", lastingTime);
        }
    }
    public virtual void BugEffect() 
    {
        Debug.Log("This bug is not implemented");
    }
    public virtual void EndBug()
    {
        Debug.Log("This bug is not implemented");
    }
}
