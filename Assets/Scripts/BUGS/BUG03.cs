using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUG03 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.tag == "FakePlayer")
        {
            collision.gameObject.GetComponent<Player>().enabled = true;
            collision.gameObject.GetComponent<Weapon>().enabled = true;
            collision.gameObject.tag = "Player";
            Destroy(gameObject);
        }
    }
}
