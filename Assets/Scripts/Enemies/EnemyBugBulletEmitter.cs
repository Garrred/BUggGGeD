using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBugBulletEmitter : MonoBehaviour
{
    public BUGFrame[] possibleBugs;
    public GameObject bugBulletPrefab;
    private BUGFrame currentBug;

    public void AddRandomBug(GameObject bugBullet)
    {
        int randomIndex = Random.Range(0, possibleBugs.Length);
        currentBug = possibleBugs[randomIndex];
        bugBullet.AddComponent(currentBug.GetType());
    }
}
