using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    const int LMB = 0;
    const int RMB = 1;
    const int MMB = 2;

    public float allowedDelta = 0.1f;
    public float moveSpeed = 8f;

    public float forwardOffset;
    public Vector3 bottomOffset;
    public Vector3 heightOffset;
    public float overlapRadius = 0.2f;

    Vector3 lastValidMoveTarget;
    Vector3 targetCorner;
    int currentCornerIndex;

    Collider[] overlapResults;

    NavMeshAgent agent;
    NavMeshPath path;

    private void Start()
    {
        overlapResults = new Collider[16];
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        lastValidMoveTarget = transform.position;

        //NavMeshSurface pong;
        //pong.BuildNavMesh();
    }
    private void Update()
    {
        bool isMouseDown = false;
        if (Input.GetMouseButton(LMB))
        {
            isMouseDown = true;
            Ray mouseCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = ~LayerMask.GetMask("Pong") & ~LayerMask.GetMask("Ignore Raycast");

            if (Physics.Raycast(mouseCast, out hit, float.PositiveInfinity, layerMask))
            {
                if (hit.transform.gameObject.tag != "NoPass")
                {
                    agent.ResetPath();
                    Vector3 lookPoint = hit.point;
                    lookPoint.y = transform.position.y;
                    transform.LookAt(lookPoint);
                    lastValidMoveTarget = hit.point;
                }
            }
        } //end of checking left mouse button

        if (Input.GetMouseButtonUp(LMB))
        {
            isMouseDown = false;
            //agent.SetDestination(lastValidMoveTarget);
            NavMesh.CalculatePath(transform.position, lastValidMoveTarget, NavMesh.AllAreas, path);
            if (path.corners.Length == 0)
            {
                lastValidMoveTarget = transform.position;
            }
            else
            {
                targetCorner = path.corners[0];
                currentCornerIndex = 0;
            }
        }

        if (Vector3.Distance(this.transform.position, lastValidMoveTarget) > allowedDelta && isMouseDown)
        {
            //Old Solution
            //Vector3 offset = transform.forward * (Time.deltaTime * moveSpeed);
            //transform.position += offset;
            Vector3 desiredPosition = this.transform.position + this.transform.forward * (Time.deltaTime * moveSpeed);
            Vector3 bottomSphere = desiredPosition + transform.forward * forwardOffset + bottomOffset;
            Vector3 topSphere = desiredPosition + transform.forward * forwardOffset + heightOffset;

            int count = Physics.OverlapCapsuleNonAlloc(bottomSphere, topSphere, overlapRadius, overlapResults);

            bool canMove = true;
            for(int i = 0; i < count; i++)
            {
                //Debug.Log(overlapResults[i].name);
                if (overlapResults[i].gameObject.tag == "NoPass")
                {
                    //currentCornerIndex += 1; //This shouldn't break anything but is just expensive. You can use it, if you feel like the code's broken
                    //if (currentCornerIndex < path.corners.Length)
                    //{
                    //    targetCorner = path.corners[currentCornerIndex];
                    //    Vector3 lookPoint = targetCorner;
                    //    lookPoint.y = transform.position.y;
                    //    transform.LookAt(lookPoint);
                    //}
                }
            }
            if (canMove)
            {
                transform.position = desiredPosition;
            }
        }
        else if (Vector3.Distance(this.transform.position, lastValidMoveTarget) > allowedDelta && !isMouseDown)
        {
            if (Vector3.Distance(transform.position, targetCorner) > allowedDelta)
            {
                Vector3 offset = transform.forward * (Time.deltaTime * moveSpeed);
                transform.position += offset;
            }

            else
            {
                currentCornerIndex += 1;
                if (currentCornerIndex < path.corners.Length)
                {
                    targetCorner = path.corners[currentCornerIndex];
                    Vector3 lookPoint = targetCorner;
                    lookPoint.y = transform.position.y;
                    transform.LookAt(lookPoint);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        //if (Vector3.Distance(this.transform.position, lastValidMoveTarget) > allowedDelta)
        //{
        //    Vector3 desiredPosition = this.transform.position + this.transform.forward * (Time.deltaTime * moveSpeed);
        //    Vector3 bottomSphere = desiredPosition + transform.forward * forwardOffset + bottomOffset;
        //    Vector3 topSphere = desiredPosition + transform.forward * forwardOffset + heightOffset;
        //    Gizmos.color = Color.green;
        //    Gizmos.DrawWireSphere(bottomSphere, overlapRadius);
        //    Gizmos.DrawWireSphere(topSphere, overlapRadius);
        //}

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(lastValidMoveTarget, .2f);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 bottomSphere = transform.position + transform.forward * forwardOffset + bottomOffset;
        Vector3 topSphere = transform.position + transform.forward * forwardOffset + heightOffset;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(bottomSphere, overlapRadius);
        Gizmos.DrawWireSphere(topSphere, overlapRadius);
    }
}
