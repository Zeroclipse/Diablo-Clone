using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class Chicken_Controller : MonoBehaviourPunCallbacks, IPunObservable
{
    Animator animator;
    [SerializeField] float moveSpeed = 8;

    int score = 0;
    [SerializeField] float timeToScore = 2;
    float currentScoreTimer = 0;

    float oneHalf = 1 / 2;
    float scoreUpdate = 0;

    bool isEating = false;
    bool isWalking = false;

    ScoreReport scoreReport;
    //bool doTest = false;

    private void Start()
    {
        scoreReport = GameObject.Find("UIManager").GetComponent<ScoreReport>();
        if (photonView.IsMine)
        {
            animator = GetComponent<Animator>();
            scoreReport.Register("local");
        }
        else
        {
            scoreReport.Register(photonView.Owner.NickName);
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            scoreReport.ScoreUpdate(photonView.Owner.NickName, score);
            return;
        }
        scoreReport.ScoreUpdate("local", score);
        Vector3 movement = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        if (movement.sqrMagnitude == 0)
        {
            isWalking = false;
            animator.SetBool("Walk", false);

            if(Input.GetKey(KeyCode.Space))
            {
                isEating = true;
                animator.SetBool("Eat", true);
                DoScoring();
            }
            else
            {
                isEating = false;
                animator.SetBool("Eat", false);
            }
        }
        else
        {
            isWalking = true;
            isEating = false;
            animator.SetBool("Walk", true);
            animator.SetBool("Eat", false);
            transform.position += movement.normalized * (moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg, 0);
        }
        //scoreBoxes["Mine"].text = string.Format("My Score: {0}", score);
    }

    void DoScoring()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentScoreTimer = timeToScore;
        }

        else
        {
            currentScoreTimer -= Time.deltaTime;
            if (currentScoreTimer <= 0)
            {
                score++;
                currentScoreTimer += timeToScore;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.IsMine)
        {
            return;
        }
        Chicken_Controller ckOther = other.gameObject.GetComponent<Chicken_Controller>();
        if (ckOther != null && isWalking)
        {
            if (ckOther.isEating)
            {
                PhotonView otherView = other.gameObject.GetComponent<PhotonView>();
                otherView.RPC("ReduceScore", RpcTarget.Others, otherView.ViewID);
               // Debug.Log("Sending an RPC Call");
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (doTest && other.gameObject.tag == "Player")
    //    {
    //        PhotonView otherView = other.gameObject.GetComponent<PhotonView>();
    //        otherView.RPC("ReduceScore", RpcTarget.Others, otherView.ViewID);
    //    }
    //}

    [PunRPC] public void ReduceScore(int ID)
    {
        if (ID == this.photonView.ViewID)
        {
            //Debug.Log("Getting a Call");
            scoreUpdate = score * oneHalf;
            score = (int)scoreUpdate;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(isEating);
            stream.SendNext(score);
        }
        else
        {
            this.isEating = (bool)stream.ReceiveNext();
            this.score = (int)stream.ReceiveNext();
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        scoreReport.UnRegister(otherPlayer.NickName);
    }


}
