using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDrop", menuName = "ItemDrop")]
public class ItemDrop : ScriptableObject
{
    [System.Serializable]
    public class Item
    {
        public int dropChance;
        public GameObject item;
    }

    public GameObject[] possibleDrops;
}
