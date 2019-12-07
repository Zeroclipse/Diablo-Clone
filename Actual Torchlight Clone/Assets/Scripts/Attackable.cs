using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class Attackable : MonoBehaviourPun
{
    const int LMB = 0;
    const int RMB = 1;
    const int MMB = 2;

    bool ready = false;
    bool isMouseDown = false;
    Character_Controller player;

    private void Start()
    {
        StartCoroutine(Check());
    }

    private void LateUpdate()
    {
        //if (firstTime == true)
        //{
        //    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
        //    firstTime = false;
        //    //Debug.Log("Finding Player");
        //}
    }
    private void Update()
    {
        isMouseDown = Input.GetMouseButton(LMB);
    }
    public void Attacked()
    {
        photonView.RPC("Die", RpcTarget.AllBufferedViaServer);
    }

    private void OnMouseDown()
    {
        NotifyPlayer();
    }

    void NotifyPlayer()
    {
        player.MoveAndAttack(this);
        //player.Tag(this.gameObject.tag);
    }

    [PunRPC]
    public void Die()
    {
        Destroy(this.gameObject);
        //Debug.Log("Destroyed");
    }

    public void OnDestroy()
    {
        GameObject ground = GameObject.FindGameObjectWithTag("Ground");

        if (ground != null)
        {
            NavMeshSurface surface = ground.GetComponent<NavMeshSurface>();
            if (surface != null)
            {
                surface.UpdateNavMesh(surface.navMeshData);
            }
        }
    }

    private void SetUp()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
    }
    IEnumerator Check()
    {
        while (!ready)
        {
            yield return new WaitForEndOfFrame();
            ready = GameObject.Find("GameMaster").GetComponent<GameStart>().ready;
        }
        SetUp();

    }
}
