using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedUp : Item
{

    public override void Start()
    {
        base.Start();
        itemName = "AttackSpeedUp";
    }
    // increase player's attack speed
    public override void TriggerEffect()
    {
        player.GetComponent<Attacks.Weapon>().timeBetweenShots /= 2;
    }

    public override void EndEffect()
    {
        player.GetComponent<Attacks.Weapon>().timeBetweenShots *= 2;
        Destroy(gameObject);
    }
}
