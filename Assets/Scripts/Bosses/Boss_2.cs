using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2 : BossBehaviors
{
    // Start is called before the first frame update
    // void Start()
    // {
    //     foreach (Transform child in transform)
    //     {
    //         child.GetComponent<Boss_2_stage_2>().enabled = true;
    //     }
    //     this.transform.GetChild(0).parent = null;
    //     this.transform.GetChild(0).parent = null;
    // }


    public Enemies.Boss boss;
    private GameObject Shuriken1;
    private GameObject Shuriken2;
    private bool splited = false;

    private BossSpawner bossSpawner;

    private GameObject player;
    private bool followingPlayer = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = transform.GetChild(0).GetComponent<Enemies.Boss>();
        bossSpawner = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BossSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followingPlayer)
        {
            transform.position = Vector2.Lerp(transform.position, player.transform.position, 10f * Time.fixedDeltaTime);
        }
        if (!splited)
            this.transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    public override void StageChangeModification()
    {
        if (boss.stage == 1)
        {
            splited = true;
            StartCoroutine(StartSplitingIntoTwo());
        }
        if (boss.stage == 2)
        {
            StartCoroutine(StartSplitingIntoFour());
            // transform.GetChild(4).GetComponent<BugBulletEmitter>().enabled = true;
        }
    }

    IEnumerator StartSplitingIntoFour()
    {
        Shuriken1.GetComponent<Boss2Stage2>().enabled = false;
        Shuriken2.GetComponent<Boss2Stage2>().enabled = false;
        transform.GetChild(4).GetComponent<BugBulletEmitter>().enabled = false;
        StartCoroutine(bossSpawner.FadeOut());
        yield return new WaitForSeconds(3);
        // gameObject.GetComponent<Animator>().SetTrigger("Stage2Start");
        Shuriken1.GetComponent<Boss2Stage2>().splitedIntoFour = true;
        Shuriken2.GetComponent<Boss2Stage2>().splitedIntoFour = true;

        followingPlayer = true;
        Shuriken1.transform.position = transform.position;
        Shuriken2.transform.position = transform.position;
        for (int i = 0; i < 2; i++)
        {
            Shuriken1.transform.GetChild(i).GetComponent<Collider2D>().enabled = false;
            Shuriken2.transform.GetChild(i).GetComponent<Collider2D>().enabled = false;
            Shuriken1.transform.GetChild(i).transform.position = transform.position;
            Shuriken2.transform.GetChild(i).transform.position = transform.position;
        }
        // foreach (Transform child in transform)
        // {
        //     child.transform.position = player.transform.position;
        // }


        Shuriken1.transform.GetChild(0).Translate(new Vector3(8f, 8f, 0));
        Shuriken1.transform.GetChild(1).Translate(new Vector3(8f, 8f, 0));
        Shuriken2.transform.GetChild(0).Translate(new Vector3(8f, 8f, 0));
        Shuriken2.transform.GetChild(1).Translate(new Vector3(8f, 8f, 0));

        // Shuriken1.transform.GetChild(0).position = player.transform.position + new Vector3(0, 5, 0);
        // Shuriken1.transform.GetChild(1).position = player.transform.position + new Vector3(0, -5, 0);
        // Shuriken2.transform.GetChild(0).position = player.transform.position + new Vector3(-5, 0, 0);
        // Shuriken2.transform.GetChild(1).position = player.transform.position + new Vector3(5, 0, 0);
        StartCoroutine(bossSpawner.FadeIn());
        for (int i = 0; i < 2; i++)
        {
            Shuriken1.transform.GetChild(i).GetComponent<Collider2D>().enabled = true;
            Shuriken2.transform.GetChild(i).GetComponent<Collider2D>().enabled = true;
        }
        yield return new WaitForSeconds(2f);
    }

    IEnumerator StartSplitingIntoTwo()
    {
        yield return new WaitForSeconds(1);
        Shuriken1 = transform.GetChild(1).gameObject;
        Shuriken2 = transform.GetChild(2).gameObject;
        // gameObject.transform.GetChild(5).GetComponent<Animator>().SetTrigger("Stage2Start");
        gameObject.GetComponent<Animator>().SetTrigger("Stage2Start");
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Animator>().enabled = false;
        Shuriken1.GetComponent<Boss2Stage2>().enabled = true;
        Shuriken2.GetComponent<Boss2Stage2>().enabled = true;
        transform.GetChild(4).gameObject.SetActive(false);
    }
}
