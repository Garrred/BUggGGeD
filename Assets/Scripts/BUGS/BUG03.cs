using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUG03 : MonoBehaviour
{
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.tag = "FakePlayer";
            other.gameObject.GetComponent<Player>().enabled = false;
            other.gameObject.GetComponent<Weapon>().enabled = false;
            Instantiate(ps, transform.position - new Vector3(-5f, -5f, 0f), Quaternion.identity);
            GameObject.FindGameObjectWithTag("Camera").GetComponent<Basics.CameraFollow>().ResetFollow();
            
        }
    }
}
