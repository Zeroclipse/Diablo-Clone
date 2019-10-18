using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    const int LMB = 0;
    const int RMB = 1;
    const int MMB = 2;

    bool isMouseDown = false;
    PlayerControl player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    private void Update()
    {
        isMouseDown = Input.GetMouseButton(LMB);
    }

    private void OnMouseDown()
    {
        NotifyPlayer(); 
    }

    private void OnMouseUp()
    {
        //NotifyPlayer();
    }

    private void OnMouseOver()
    {
        //if (isMouseDown)
        //    NotifyPlayer();
    }

    void NotifyPlayer()
    {
        player.MoveAndAttack(this);
    }
}
