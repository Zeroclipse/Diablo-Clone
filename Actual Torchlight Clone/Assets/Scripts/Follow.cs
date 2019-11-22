using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Transform followTarget;
    Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        if (followTarget == null)
        {
            GameObject temp = GameObject.Find("Player");
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
