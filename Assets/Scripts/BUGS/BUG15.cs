using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUGS
{
    public class BUG15 : BUGFrame
    {
        public GameObject zanzou;
        public float zanzouCreationInterval = 0.1f;

        GameObject zanzouParent;
        // Start is called before the first frame update
        void Start()
        {
            bugText = "CPU Temp: 999°C";
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (remainingTime > 0.1f)
            {
                remainingTime -= Time.deltaTime;
                zanzouCreationInterval -= Time.deltaTime;
                if (zanzouCreationInterval <= 0)
                {
                    GameObject currentZanzou = Instantiate(zanzou, collision.transform.position, collision.transform.rotation);
                    currentZanzou.transform.SetParent(zanzouParent.transform);
                    zanzouCreationInterval = Random.Range(0.05f, 0.2f);
                }
            }
        }

        public override void BugStart()
        {
            zanzouParent = new GameObject("zanzouParent");
            zanzou = Resources.Load<GameObject>("Prefabs/Player/PlayerZanzou");
            remainingTime = lastingTime;
        }

        public override void BugEnd()
        {
            Destroy(zanzouParent);
        }
    }
}