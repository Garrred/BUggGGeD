using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatling : Item
{
    private Attacks.Weapon weapon;
    private bool activated = false;
    private float originalAttackSpeed;
    public override void Start()
    {
        base.Start();
        itemName = "Gatling";
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (activated)
        {
            weapon.buggedDirection = Quaternion.Euler(0, 0, weapon.transform.rotation.z + Random.Range(-60f, 60f));
        }
    }
    public override void TriggerEffect()
    {
        weapon = player.GetComponent<Attacks.Weapon>();
        activated = true;
        // originalAttackSpeed = weapon.timeBetweenShots;
        weapon.timeBetweenShots = 0.03f;
    }

    public override void EndEffect()
    {
        weapon.buggedDirection = Quaternion.Euler(0, 0, 0);
        weapon.timeBetweenShots = 0.2f;
        Destroy(gameObject);
    }
}
