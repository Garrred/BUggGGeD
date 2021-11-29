using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BUGFrame : MonoBehaviour
{
    public string bugText;
    public float lastingTime = 5f;
    public float remainingTime = -10f;
    public bool bugEnabled = true;


    [HideInInspector]
    public Collider2D collision;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (bugEnabled && other.gameObject.tag == "Player")
        {
            remainingTime = lastingTime;
            this.collision = other;
            StartCoroutine(DisplayWarning());
            BugStart();
            // GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).text = bugText;
            Invoke("BugEnd", remainingTime);
        }
    }
    IEnumerator DisplayWarning()
    {
        collision.transform.parent.GetChild(1).gameObject.GetComponent<TMPro.TextMeshPro>().text = bugText;
        collision.transform.parent.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        collision.transform.parent.GetChild(1).gameObject.SetActive(false);
    }
    public virtual void BugStart() 
    {
        Debug.Log("This bug is not implemented");
    }
    public virtual void BugEnd()
    {
        Debug.Log("This bug is not implemented");
    }
}
