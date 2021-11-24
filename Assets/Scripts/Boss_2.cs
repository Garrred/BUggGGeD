using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Boss_2_stage_2>().enabled = true;
        }
        this.transform.GetChild(0).parent = null;
        this.transform.GetChild(0).parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 100 * Time.deltaTime);
    }
}
