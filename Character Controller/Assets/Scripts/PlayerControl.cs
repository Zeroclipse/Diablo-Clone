using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    const int LMB = 0;
    const int RMB = 1;
    const int MMB = 2;

    public float allowedDelta = 0.1f;
    public float moveSpeed = 8f;

    Vector3 lastValidMoveTarget;

    private void Update()
    {
        if (Input.GetMouseButton(LMB))
        {
            Ray mouseCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = ~LayerMask.GetMask("Pong") & ~LayerMask.GetMask("Ignore Raycast");

            if (Physics.Raycast(mouseCast, out hit, float.PositiveInfinity, layerMask))
            {
                Vector3 lookPoint = hit.point;
                lookPoint.y = transform.position.y;
                transform.LookAt(lookPoint);
                lastValidMoveTarget = hit.point;
            }
        }

        if (Vector3.Distance(this.transform.position, lastValidMoveTarget) > allowedDelta)
        {
            Vector3 offset = transform.forward * (Time.deltaTime * moveSpeed);
            transform.position += offset;
        }
    }
}
