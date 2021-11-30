using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugTextFollow : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + Vector3.up * 1.5f;
    }
}
