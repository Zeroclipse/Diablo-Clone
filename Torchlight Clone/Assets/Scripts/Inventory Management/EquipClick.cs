﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipClick : MonoBehaviour
{
    public bool equipSelected = false;
    private AudioSource cameraAudio;
    public AudioClip selectSound;

    private void Awake()
    {
        cameraAudio = this.gameObject.GetComponent<AudioSource>();
    }

    public void _SelectEquippedItem(Image button)
    {
        if (equipSelected == false)
        {
            button.color = Color.red;
            cameraAudio.clip = selectSound;
            cameraAudio.Play();
            equipSelected = true;
        }
        else
        {
            if (button.color == Color.red)
            {
                equipSelected = false;
                button.color = Color.white;
            }
        }
    }
}
