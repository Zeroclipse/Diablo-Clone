using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    const int LMB = 0;
    const int RMB = 1;
    const int MMB = 2;

    bool firstTime = true;
    bool isMouseDown = false;
    Character_Controller player;

    private void Start()
    {

    }

    private void Update()
    {
        if (firstTime == true)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Controller>();
            firstTime = false;
        }
        isMouseDown = Input.GetMouseButton(LMB);
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
}
