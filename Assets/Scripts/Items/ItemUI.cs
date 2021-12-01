using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioClip healthUp;
    public AudioClip attackSpeedUp;
    public AudioClip gatling;
    public AudioSource audioSource;
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
                UseItemAndPlayAudio(currentItem1);
                item1.SetActive(false);
                hasItem1 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hasItem2)
            {
                UseItemAndPlayAudio(currentItem2);
                item2.SetActive(false);
                hasItem2 = false;
            }
        }
    }

    void UseItemAndPlayAudio(GameObject item)
    {
        switch (item.GetComponent<Item>().UseItem())
        {
            case "HealthUp":
                audioSource.PlayOneShot(healthUp);
                break;
            case "AttackSpeedUp":
                audioSource.PlayOneShot(attackSpeedUp);
                break;
            case "Gatling":
                audioSource.PlayOneShot(gatling);
                break;
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
            audioSource.PlayOneShot(pickupSound);
            return true;
        }
        else if (!hasItem2)
        {
            item2.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            item2.SetActive(true);
            currentItem2 = item.gameObject;
            hasItem2 = true;
            audioSource.PlayOneShot(pickupSound);
            return true;
        }
        return false;
    }
}
