using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.AI;

public class Character_Controller : MonoBehaviourPunCallbacks, IPunObservable
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
    string tag;
    bool isMouseDown = false;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            overlapResults = new Collider[16];
            rayHits = new RaycastHit[16];
            agent = GetComponent<NavMeshAgent>();
            path = new NavMeshPath();
            lastValidMoveTarget = transform.position;
        }
    }

    //// Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            isMouseDown = false;
            HandleMouseDown();
            //HandleMouseUp();
            MovePlayer();
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
    private void MovePlayer()
    {
        if (Vector3.Distance(this.transform.position, lastValidMoveTarget) > allowedDelta && isMouseDown)
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
        else if (Vector3.Distance(this.transform.position, lastValidMoveTarget) > allowedDelta && !isMouseDown)
        {
            if (Vector3.Distance(transform.position, targetCorner) > allowedDelta)
            {
                Debug.Log("Broken");
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
                else if (attackTarget != null)
                {
                    //Additional Attack code needed!!!!!!
                    if (tag == "Barrel")
                    {
                        Destroy(attackTarget.gameObject);
                    }
                    Vector3 lookPoint = attackTarget.transform.position;
                    lookPoint.y = this.transform.position.y;
                    this.transform.LookAt(lookPoint);
                    //HAAAAACK
                    attackTarget = null;
                    currentMode = IDLE;
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
            NavMesh.CalculatePath(transform.position, lastValidMoveTarget, NavMesh.AllAreas, path);
            if (path.corners.Length == 0 && attackTarget == null)
            {
                lastValidMoveTarget = transform.position;
                print("Invalid Path");
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

            if (currentMode != ATTACKING && Physics.Raycast(mouseCast, out hit, float.PositiveInfinity, layerMask))
            {
                if (hit.transform.gameObject.tag != "NoPass")
                {
                    agent.ResetPath();
                    attackTarget = null;
                    Vector3 lookPoint = hit.point;
                    lookPoint.y = transform.position.y;
                    transform.LookAt(lookPoint);
                    lastValidMoveTarget = hit.point;
                }

                else if (attackTarget != null)
                {
                    agent.ResetPath();
                    Vector3 lookPoint = attackTarget.gameObject.transform.position;
                    lookPoint.y = transform.position.y;
                    transform.LookAt(lookPoint);
                    lastValidMoveTarget = attackTarget.gameObject.transform.position;
                }
            }
        } //end of checking left mouse button
    }

    public void MoveAndAttack(Attackable target)
    {
        if (target != attackTarget)
        {
            Debug.Log("Attack Target Set");
            attackTarget = target;
            lastValidMoveTarget = attackTarget.gameObject.transform.position;
            currentMode = ATTACKING;
        }
    }

    //public void Tag(string newTag)
    //{
    //    tag = newTag;
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    Vector3 bottomSphere = transform.position + transform.forward * forwardOffset + bottomOffset;
    //    Vector3 topSphere = transform.position + transform.forward * forwardOffset + heightOffset;
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(bottomSphere, overlapRadius);
    //    Gizmos.DrawWireSphere(topSphere, overlapRadius);
    //}
}
