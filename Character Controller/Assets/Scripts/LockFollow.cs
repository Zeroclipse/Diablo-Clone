using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFollow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    private void Start()
    {
        offset = this.transform.position - target.position;
    }

    private void LateUpdate()
    {
        this.transform.position = target.position + offset;
    }
}
