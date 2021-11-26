using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private GameObject item1;
    private GameObject item2;
    private bool hasItem1 = false;
    private bool hasItem2 = false;

    private GameObject currentItem1;
    private GameObject currentItem2;

    void Start()
    {
        item1 = transform.GetChild(0).GetChild(0).gameObject;
        item2 = transform.GetChild(1).GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (hasItem1)
            {
                currentItem1.SetActive(true);
                currentItem1.GetComponent<Item>().UseItem();
                item1.SetActive(false);
                hasItem1 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hasItem2)
            {
                currentItem2.SetActive(true);
                currentItem2.GetComponent<Item>().UseItem();
                item2.SetActive(false);
                hasItem2 = false;
            }
        }
    }

    public bool PickupItem(Item item)
    {
        if (!hasItem1)
        {
            item1.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            item1.SetActive(true);
            currentItem1 = item.gameObject;
            hasItem1 = true;
            return true;
        }
        else if (!hasItem2)
        {
            item2.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            item2.SetActive(true);
            currentItem2 = item.gameObject;
            hasItem2 = true;
            return true;
        }
        return false;
    }
}
