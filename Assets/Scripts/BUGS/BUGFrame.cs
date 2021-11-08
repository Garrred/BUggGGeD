using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUGFrame : MonoBehaviour
{
    public string BUGNumber;
    public float lastingTime;
    private float remainingTime = -10f;

    public Collision2D collision;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = lastingTime;
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (remainingTime > 0)
    //     {
    //         remainingTime -= Time.deltaTime;
    //     }
    //     else if (remainingTime >= -1)
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            BugEffect();
            Invoke("EndBug", lastingTime);
        }
    }

    void BugEffect() 
    {
        Debug.Log("This bug is not implemented");
    }

    void EndBug()
    {
        Debug.Log("This bug is not implemented");
    }
}
