using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastBug : MonoBehaviour
{
    public GameObject player;
    public float timeBetweenBugs = 25f;
    public BUGFrame[] bugs;
    public Image backGround;


    public BUGFrame currentBug;
    private bool isChangingColor = false;

    private float remainingTime;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = timeBetweenBugs;
        StartCoroutine(GetPlayer());

    }

    void Update()
    {
        if (!isChangingColor)
        {
            remainingTime -= Time.deltaTime;
            if (player != null && remainingTime <= 0 && !player.GetComponent<Basics.Player>().hasBugNow)
            {
                backGround.color = new Color(255, 255, 255);
                currentBug = bugs[transform.GetComponent<Enemies.Boss>().stage];
                StartCoroutine(StartChangingColor());
            }
        }
    }
    IEnumerator StartChangingColor()
    {
        isChangingColor = true;
        for (int j = 0; j < 20; j++)
        {
            backGround.color = Color.Lerp(Color.white, Color.red, j / 20f);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        isChangingColor = false;
        currentBug.OnTriggerEnter2D(player.gameObject.GetComponent<Collider2D>());
        remainingTime = timeBetweenBugs;


        for (int j = 0; j < 20; j++)
        {
            backGround.color = Color.Lerp(Color.red, Color.white, j / 20f);
            yield return new WaitForSeconds(0.05f);
        }

    }
    IEnumerator GetPlayer()
    {
        yield return new WaitForSeconds(1f);
        player = transform.GetComponent<Enemies.Boss>().player.gameObject;
    }
}