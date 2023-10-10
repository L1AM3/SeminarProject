using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public static class Timer
{
    public static float TimeRemaining = 120;
    public static event Action UpdatedTime;
    public static bool IsRunning = true;

    public static void Timing(float dt)
    {
        if (IsRunning)
        {
            if (TimeRemaining > 0)
            {
                UpdatedTime?.Invoke();
                TimeRemaining -= dt;
            }
            else
            {
                Debug.Log("Time has run out!");
                TimeRemaining = 0;
                IsRunning = false;
                SceneManager.LoadScene("BattleField");
            }
        }
    }


}
