using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.AI;

public class Character_Controller : MonoBehaviourPunCallbacks
{
    const int LMB = 0;
    const int RMB = 1;
    const int MMB = 2;

    const int MOVING = 1;
    const int ATTACKING = 2;
    const int IDLE = 0;

    int currentMode = 0;

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

    RaycastHit[] rayHits;

    NavMeshAgent agent;
    NavMeshPath path;

    Attackable attackTarget;
    bool isMouseDown = false;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            position = new Vector3();
            overlapResults = new Collider[16];
            rayHits = new RaycastHit[16];
            agent = GetComponent<NavMeshAgent>();
            path = new NavMeshPath();
            lastValidMoveTarget = transform.position;
            lastValidMoveTarget.y = 0;
        }
    }

    //// Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            isMouseDown = false;
            HandleMouseDown();
            HandleMouseUp();
            MovePlayer();
        }
    }
    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    throw new System.NotImplementedException();
    //}
    private void MovePlayer()
    {
        position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        if (Vector3.Distance(position, lastValidMoveTarget) > allowedDelta && isMouseDown)
        {
            //Old Solution
            Vector3 desiredPosition = this.transform.position + this.transform.forward * (Time.deltaTime * moveSpeed);
            Vector3 bottomSphere = desiredPosition + transform.forward * forwardOffset + bottomOffset;
            Vector3 topSphere = desiredPosition + transform.forward * forwardOffset + heightOffset;

            int count = Physics.OverlapCapsuleNonAlloc(bottomSphere, topSphere, overlapRadius, overlapResults);

            bool canMove = true;
            for (int i = 0; i < count; i++)
            {
                //Debug.Log(overlapResults[i].name);
                if (overlapResults[i].gameObject.tag == "NoPass")
                {

                }
            }
            if (canMove)
            {
                transform.position = desiredPosition;
            }
        }
        else if (Vector3.Distance(position, lastValidMoveTarget) > allowedDelta && !isMouseDown)
        {
            if (Vector3.Distance(position, targetCorner) > allowedDelta)
            {
                //Debug.Log("Broken: " + Vector3.Distance(transform.position, targetCorner));
                Vector3 offset = transform.forward * (Time.deltaTime * moveSpeed);
                transform.position += offset;
            }

            else
            {
                //Debug.Log("In statement");
                currentCornerIndex += 1;
                if (currentCornerIndex < path.corners.Length)
                {
                    targetCorner = path.corners[currentCornerIndex];
                    Vector3 lookPoint = targetCorner;
                    lookPoint.y = transform.position.y;
                    transform.LookAt(lookPoint);
                }
                else
                {
                    //Debug.Log("Here");
                    targetCorner = this.transform.position;
                    if (attackTarget != null)
                    {
                        //Additional Attack code needed!!!!!!
                        Vector3 lookPoint = attackTarget.transform.position;
                        lookPoint.y = this.transform.position.y;
                        this.transform.LookAt(lookPoint);
                        //HAAAAACK
                        attackTarget = null;
                        agent.SetDestination(this.transform.position);
                        attackTarget.Attacked();
                        currentMode = IDLE;
                    }
                }
            }
        }
    }

    private void HandleMouseUp()
    {
        if (Input.GetMouseButtonUp(LMB))
        {
            isMouseDown = false;
            agent.SetDestination(lastValidMoveTarget);
            NavMesh.CalculatePath(position, lastValidMoveTarget, NavMesh.AllAreas, path);
            if (path.corners.Length == 0 && attackTarget == null)
            {
                lastValidMoveTarget = transform.position;
                lastValidMoveTarget.y = 0;
                //print("Invalid Path");
            }

            else if (path.corners.Length == 0 && attackTarget != null)
            {
                Physics.RaycastNonAlloc(new Ray(transform.position, transform.forward), rayHits);

                foreach (RaycastHit hit in rayHits)
                {
                    if (hit.transform == null)
                    {
                        attackTarget = null;
                    }

                    else if (hit.transform.gameObject == attackTarget.gameObject)
                    {
                        NavMeshHit navHit;
                        NavMesh.SamplePosition(hit.transform.position, out navHit, 3f, NavMesh.AllAreas);
                        NavMesh.CalculatePath(transform.position, navHit.position, NavMesh.AllAreas, path);
                        targetCorner = path.corners[0];
                        currentCornerIndex = 0;
                        break;
                    }
                }
            }
            else
            {
                targetCorner = path.corners[0];
                currentCornerIndex = 0;
            }
        }
    }
    private void HandleMouseDown()
    {
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
                    currentMode = IDLE;
                    //Debug.Log("No Pass");
                    agent.ResetPath();
                    attackTarget = null;
                    Vector3 lookPoint = hit.point;
                    lookPoint.y = transform.position.y;
                    transform.LookAt(lookPoint);
                    lastValidMoveTarget = hit.point;
                    lastValidMoveTarget.y = 0;
                }

                else if (attackTarget != null)
                {
                    agent.ResetPath();
                    Vector3 lookPoint = attackTarget.gameObject.transform.position;
                    lookPoint.y = transform.position.y;
                    transform.LookAt(lookPoint);
                    lastValidMoveTarget = attackTarget.gameObject.transform.position;
                    lastValidMoveTarget.y = 0;
                }
            }
        } //end of checking left mouse button
    }

    public void MoveAndAttack(Attackable target)
    {
        if (target != attackTarget)
        {
            //Debug.Log("Attack Target Set");
            attackTarget = target;
            lastValidMoveTarget = attackTarget.gameObject.transform.position;
            currentMode = ATTACKING;
        }
    }
}
