using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public float totalTime = 4;
    public bool doingThings;
    public string words = "Connecting";
    public Text connectingText;
    public GameObject connectingCanvas;
    public void Load()
    {
        connectingCanvas.SetActive(true);
        doingThings = true;
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        float elapsedTime = 0;
        float timer = totalTime / 4f;
        float timer2 = timer + timer;
        float timer3 = timer + timer2;
        float timer4 = timer + timer3;
        while (doingThings)
        {
            elapsedTime += timer;
            yield return new WaitForSeconds(timer);
            if (elapsedTime % timer4 == 0)
            {
                connectingText.text = words + "...";
            }
            else if (elapsedTime % timer3 == 0)
            {
                connectingText.text = words + "..";
            }

            else if (elapsedTime % timer2 == 0)
            {
                connectingText.text = words + ".";
            }
            else if (elapsedTime % timer == 0)
            {
                connectingText.text = words;
            }
        }
    }

    public void Stop()
    {
        StartCoroutine(Stopping());
    }

    IEnumerator Stopping()
    {
        yield return new WaitForSeconds(5);
        doingThings = false;
        connectingCanvas.SetActive(false);
    }
}
