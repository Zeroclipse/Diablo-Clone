using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHighlight : MonoBehaviour
{
    public Renderer myRenderer;

    private void OnMouseEnter()
    {
        myRenderer.material.SetFloat("_HighlightOn", 1);
    }

    private void OnMouseExit()
    {
        myRenderer.material.SetFloat("_HighlightOn", 0);
    }
}
