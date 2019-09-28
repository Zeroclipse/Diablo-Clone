using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_Game : MonoBehaviour
{
    #region Test Closer
    //This is temporary and just for making sure the game closes early on
    private void Awake()
    {
        GetComponent<Player_Input>().OnEscPress += Close;
    }
    #endregion
    #region Close The Game
    //Closes the game when called
    public void Close()
    {
        Application.Quit();
    }
    #endregion
}
