using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBugs : MonoBehaviour
{
    [Space(5)]
    [Header("Bug Casting Properties")]
    // public bool ableToCast = false;
    public BUGFrame bug;
    public int attacksBeforeBug = 0;
    public int attackCount = 0;
    public float stopTimeBeforeCasting = 2f;

    public IEnumerator CastBug(GameObject target)
    {
        // yield return new WaitForSeconds(0.5f);
        float chargingTime = stopTimeBeforeCasting;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        while (sprite.color != Color.red)
        {
            sprite.color = Color.Lerp(sprite.color, Color.red, Time.deltaTime * chargingTime * 10);
            yield return null;
        }

        if (target != null && !target.GetComponent<Basics.Player>().hasBugNow)
        {
            this.bug.OnTriggerEnter2D(target.GetComponent<Collider2D>());
        }
        // yield return new WaitForSeconds(0.5f);
        while (sprite.color != Color.white)
        {
            sprite.color = Color.Lerp(sprite.color, Color.white, Time.deltaTime * chargingTime * 10);
            yield return null;
        }
    }
}
