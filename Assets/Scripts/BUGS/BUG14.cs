using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG14 : BUGFrame
    {
        private float freezeTime = 1f;
        private Transform player;
        private Transform enemies;
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            enemies = GameObject.FindGameObjectWithTag("WaveSpawner").transform.GetChild(0);
        }

        // Update is called once per frame
        void Update()
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                if (freezeTime > 0) 
                {
                    freezeTime -= Time.deltaTime;
                    if (freezeTime <= 0)
                    {
                        Freeze();
                        freezeTime = Random.Range(0.2f, 0.5f);
                        StartCoroutine(Melt());
                    }
                }
            }
        }

        public override void BugStart()
        {
        }
        public override void BugEnd()
        {
        }
        public void Freeze()
        {
            Time.timeScale = 0f;
        }
        IEnumerator Melt()
        {
            yield return new WaitForSecondsRealtime(freezeTime);
            Time.timeScale = 1f;
            player.Translate(player.GetComponent<Basics.Player>().movementInput * 2 * freezeTime);
        }
    }
}