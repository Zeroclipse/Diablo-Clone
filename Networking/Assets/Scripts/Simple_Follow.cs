using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Follow : MonoBehaviour
{
    Transform followTarget;
    Vector3 cameraOffset;
    private void Start()
    {
        //cameraOffset = followTarget.position - this.transform.position;
    }

    private void Update()
    {
        if (followTarget == null)
        {
            GameObject temp = GameObject.Find("ChickenPlayer");
            if (temp != null)
            {
                followTarget = temp.transform;
                cameraOffset = followTarget.position - this.transform.position;
            }
        }
    }
    private void LateUpdate()
    {
        if (followTarget != null)
        {
            this.gameObject.transform.position = followTarget.position - cameraOffset;
        }
    }
}
