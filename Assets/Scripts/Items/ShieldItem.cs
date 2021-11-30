using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : Item
{
    public GameObject shield;
    private bool activated = false;
    private GameObject spawnedShield;

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void TriggerEffect()
    {
        spawnedShield = Instantiate(shield, player.transform.position, Quaternion.identity);
        spawnedShield.transform.SetParent(player.transform);
    }

    public override void EndEffect()
    {
        Destroy(spawnedShield);
    }
}