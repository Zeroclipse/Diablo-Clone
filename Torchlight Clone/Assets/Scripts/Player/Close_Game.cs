using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Game : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Player_Input>().OnEscPress += Close;
    }

    public void Close()
    {
        Application.Quit();
    }
}
