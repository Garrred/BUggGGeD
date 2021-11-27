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

    void Start()
    {
        boss = transform.GetChild(0).GetComponent<Enemies.Boss>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    IEnumerator StartSplitingIntoTwo()
    {
        yield return new WaitForSeconds(1);
        Shuriken1 = transform.GetChild(1).gameObject;
        Shuriken2 = transform.GetChild(2).gameObject;
        Shuriken1.transform.position = Vector3.MoveTowards(transform.position, new Vector3(-5, 0, 0), 5);
        Shuriken2.transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 0, 0), 5);
        Shuriken1.GetComponent<Boss2Stage2>().enabled = true;
        Shuriken2.GetComponent<Boss2Stage2>().enabled = true;
    }
}
