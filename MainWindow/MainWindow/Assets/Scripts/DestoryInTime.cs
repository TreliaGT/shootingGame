using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryInTime : MonoBehaviour
{
    [Header("destoryInTime")]
    public bool singleframe = false;
    public float destorytime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestoryRoutine());
    }

    IEnumerator DestoryRoutine()
    {
        if (singleframe)
        {
            yield return null;
            yield return new WaitForEndOfFrame();
        }
        else
        {
            yield return new WaitForSeconds(destorytime);
        }
        Destroy(gameObject);
    }

}
