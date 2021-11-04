using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUG01 : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.GetComponent<Weapon>().bullet = Resources.Load<GameObject>("Prefabs/Player_Bullet");
        GameObject.Find("Player_Body").SetActive(false);
        GameObject.Find("ShootPos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BasicBullet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
