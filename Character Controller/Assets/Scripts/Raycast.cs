using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    const int LMB = 0;
    const int RMB = 1;
    const int MMB = 2;

    public Transform targetPoint;

    private void Update()
    {
        if (Input.GetMouseButton(LMB))
        {
            Ray mouseCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = ~LayerMask.GetMask("Pong");

            if (Physics.Raycast(mouseCast, out hit, float.PositiveInfinity, layerMask))
            {
                targetPoint.position = hit.point;
            }
        }
    }
}
