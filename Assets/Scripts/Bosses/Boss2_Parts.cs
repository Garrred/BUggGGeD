using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Parts : Enemies.Enemy
{
    public override void takeDamage(float damage)
    {
        if (!isInvincible)
        {
            transform.parent.parent.GetChild(0).GetComponent<Enemies.Boss>().takeDamage(damage);
            Flash(transform.parent.parent);
        }
    }

}
