using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastBug : MonoBehaviour
{
    public GameObject player;
    public float timeBetweenBugs = 25f;
    public BUGFrame[] bugs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetPlayer());
        StartCoroutine(SpawnBug());
    }

    IEnumerator GetPlayer()
    {
        yield return new WaitForSeconds(1f);
        player = transform.GetComponent<Enemies.Boss>().player.gameObject;
    }

    IEnumerator SpawnBug()
    {
        yield return new WaitForSeconds(timeBetweenBugs);
        bugs[transform.GetComponent<Enemies.Boss>().stage].OnTriggerEnter2D(player.GetComponent<Collider2D>());
        StartCoroutine(SpawnBug());
    }
}
