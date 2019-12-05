using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Transform followTarget;
    public Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        if (followTarget == null)
        {
            StartCoroutine(FollowDelay());
        }
    }

    private void LateUpdate()
    {
        if (followTarget != null)
        {
            this.gameObject.transform.position = followTarget.position - cameraOffset;
        }
    }
    IEnumerator FollowDelay()
    {
        yield return new WaitForSeconds(1f);
        GameObject temp = GameObject.Find("Player");
        if (temp != null)
        {
            this.gameObject.GetComponent<Transform>().Rotate(new Vector3(40, 180, 0));
            followTarget = temp.transform;
        }
    }
}
