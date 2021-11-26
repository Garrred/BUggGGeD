using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : Item
{
    public int healAmount = 1;

    public override void TriggerEffect()
    {
        player.GetComponent<Basics.Player>().Heal(healAmount);
        Destroy(gameObject);
    }

    public override void EndEffect()
    {
        // Do nothing
    }
}
