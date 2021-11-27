using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviors : MonoBehaviour
{
    public virtual void StageChangeModification()
    {
        Debug.Log("No Effects Happening During Stage Change");
    }
}
