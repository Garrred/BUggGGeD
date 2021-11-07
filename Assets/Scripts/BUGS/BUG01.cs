using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG01 : MonoBehaviour
    {
        public Basics.Player player;
        // Start is called before the first frame update

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                player = other.GetComponent<Basics.Player>();
                player.GetComponent<Attacks.Weapon>().bullet = Resources.Load<GameObject>("Prefabs/Player_Bullet");
                player.transform.Find("Player_Body").gameObject.SetActive(false);
                player.transform.Find("ShootPos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BasicBullet");
            }
        }
    }
}