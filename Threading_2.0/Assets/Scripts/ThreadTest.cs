using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ThreadTest : MonoBehaviour
{
    Thread ping;
    float workTime = 10;
    float startTime;
    float currentTime;

    public UnityEngine.UI.Text textBox;

    System.Diagnostics.Stopwatch timer;

    private void Start()
    {
        timer = new System.Diagnostics.Stopwatch();
    }

    private void Update()
    {
        if(ping == null)
        {
            textBox.text = "Thread is not created...PONG";
        }

        else if (ping.ThreadState == ThreadState.Unstarted)
        {
            textBox.text = "Thread is not started...PONG";
        }

        else if (ping.ThreadState == ThreadState.Running)
        {
            textBox.text = "Thread is doing something...PONG";
        }

        else if (ping.ThreadState == ThreadState.WaitSleepJoin)
        {
            textBox.text = "Thread is sleeping...PONG";
        }

        else if (ping.ThreadState == ThreadState.Stopped)
        {
            textBox.text = "Thread is stopped...PONG";
        }
    }

    void DoStuff()
    {
        timer.Start();

        System.Random random = new System.Random();

        int z = 0;
        while ((timer.Elapsed.TotalSeconds) < workTime)
        {
            for(long i=0;i<10000;i++)
            {
                int x = random.Next(1, 21);
                if (x == 20)
                {
                    z++;
                    Debug.Log("Ping");
                }
            }
            Thread.Sleep(500);
        }
        timer.Stop();
        timer.Reset();
        Debug.Log("Ping: " + z);
    }

    public void CreateThread()
    {
        if ((ping != null && ping.ThreadState == ThreadState.Stopped) || ping == null)
        {
            ping = new Thread(DoStuff);
            ping.Start();
        }
        else
        {
            Debug.Log("Did not start thread...PONG");
        }
    }

    public void StartThread()
    {
        //ping.Start();
    }
}
