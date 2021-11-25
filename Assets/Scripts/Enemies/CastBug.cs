using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastBug : MonoBehaviour
{
    public GameObject player;
    public float timeBetweenBugs = 25f;
    public BUGFrame[] bugs;

    public BUGFrame currentBug;

    private float remainingTime;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = timeBetweenBugs;
        StartCoroutine(GetPlayer());
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0 && !player.GetComponent<Basics.Player>().hasBugNow)
        {
            SpawnBug();
            remainingTime = timeBetweenBugs;
        }
    }
    IEnumerator GetPlayer()
    {
        yield return new WaitForSeconds(1f);
        player = transform.GetComponent<Enemies.Boss>().player.gameObject;
    }

    void SpawnBug()
    {
        currentBug = bugs[transform.GetComponent<Enemies.Boss>().stage];
        currentBug.OnTriggerEnter2D(player.gameObject.GetComponent<Collider2D>());
    }

    public void StopSpawningBug()
    {
        // currentBug.BugEnd();
    }
}
