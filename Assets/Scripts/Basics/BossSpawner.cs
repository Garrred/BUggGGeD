using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public float timeBeforeSpawn = 5f;
    private GameObject currentBoss;
    private SpriteRenderer[] spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBoss());
    }

    IEnumerator SpawnBoss()
    {
        if (bossPrefab != null)
        {
            yield return new WaitForSeconds(timeBeforeSpawn);
            gameObject.GetComponent<AudioSource>().Play();

            spriteRenderer = bossPrefab.GetComponentsInChildren<SpriteRenderer>();
            // foreach (SpriteRenderer sr in spriteRenderer)
            // {
            //     sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
            // }
            bossPrefab.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    public IEnumerator FadeIn()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.05f);
            foreach (SpriteRenderer sr in spriteRenderer)
            {
                sr.color += new Color(0, 0, 0, 0.05f);
            }
        }
    }

    public IEnumerator FadeOut()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.05f);
            foreach (SpriteRenderer sr in spriteRenderer)
            {
                Debug.Log(sr.color);
                sr.color -= new Color(0, 0, 0, 0.05f);
            }
        }
    }
}
