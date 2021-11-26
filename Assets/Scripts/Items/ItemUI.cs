using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    private GameObject[] itemFrames;
    private int occupiedFrames = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.GetChild(0).GetComponent<Item>().UseItem();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.GetChild(1).GetComponent<Item>().UseItem();
        }
    }
    public void PickupItem(Item item)
    {

    }
}
