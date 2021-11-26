using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float lastingTime = 10f;
    public float flyAwaySpeed = 1f;
    public float lifeTime = 10f;
    private Vector3 flyAwayDirection = Vector3.up;
    public GameObject itemUI;


    // Start is called before the first frame update
    void Start()
    {
        flyAwayDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.fixedDeltaTime;
            transform.Translate(flyAwayDirection * flyAwaySpeed * Time.deltaTime);
        }
        else if (lifeTime > -5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PickupItem();
        }
    }

    public virtual void PickupItem()
    {
        itemUI.GetComponent<ItemUI>().PickupItem(this);
        lifeTime = -10f;
        gameObject.SetActive(false);
    }

    public void UseItem()
    {
        TriggerEffect();
        Destroy(gameObject);
    }

    public virtual void TriggerEffect()
    {
        Debug.Log("Item effect not implemented");
    }
}