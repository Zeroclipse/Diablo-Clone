using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParent : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Parenting());
    }

    IEnumerator Parenting()
    {
        yield return new WaitForEndOfFrame();
        this.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Ground").transform);
    }
}
