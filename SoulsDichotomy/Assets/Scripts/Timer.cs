using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;

    private float timeCount;
    private bool timerStarted;

    public delegate void OnTimeExpire();
    public OnTimeExpire timeExpire;

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            if (timeCount > 0)
            {
                timeCount -= Time.deltaTime;
            }
            else
            {
                timerStarted = false;
                timeExpire();
            }
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
        timeCount= time;
    }

    public float GetTime()
    {
        return time;
    }

}
