using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG11 : BUGFrame
    {
        SpriteRenderer[] playerSprites;
        public override void BugStart()
        {
            playerSprites = collision.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in playerSprites)
            {
                sprite.enabled = false;
            }
        }

        public override void BugEnd()
        {
            foreach (SpriteRenderer sprite in playerSprites)
            {
                sprite.enabled = true;
            }
        }
    }
}