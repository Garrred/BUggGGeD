using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    private GameObject item1;
    private GameObject item2;
    private bool hasItem1 = false;
    private bool hasItem2 = false;

    void Start()
    {
        item1 = transform.GetChild(0).gameObject;
        item2 = transform.GetChild(1).gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (item1.GetComponent<Item>() != null)
            {
                item1.GetComponent<Item>().UseItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (item2.GetComponent<Item>() != null)
            {
                item2.GetComponent<Item>().UseItem();
            }
        }
    }
    public void PickupItem(Item item)
    {
        if (!hasItem1)
        {
            item1.GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            hasItem1 = true;
        }
        else if (!hasItem2)
        {
            item2.GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            hasItem2 = true;
        }
        else
        {
            Debug.Log("No more room for items");
        }

    }
}
