using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float timeLimit;
    private float timeRemaining;
    private bool timerIsRunning = false;

    public float TimeRemaining { get => timeRemaining; }

    public Timer(float duration)
    {
        SetTimeLimit(duration);
        StopTimer();
    }

    public void SetTimeLimit(float value)
    {
        timeLimit = value;
        timeRemaining = timeLimit;
    }

    public void StartTimer()
    {
        timeRemaining = timeLimit;
        timerIsRunning = true;
    }

    public void UpdateTimer()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                StopTimer();
            }
        }
    }

    public void StopTimer()
    {
        timeRemaining = 0;
        timerIsRunning = false;
    }

    public bool IsTimerStoped()
    {
        return (!timerIsRunning && timeRemaining <= 0);
    }
}