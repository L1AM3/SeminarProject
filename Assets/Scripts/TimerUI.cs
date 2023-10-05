using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerUI : MonoBehaviour
{
    public TMP_Text TimerText;

    private void Start()
    {
        Timer.UpdatedTime += DisplayTime;
    }

    public void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(Timer.TimeRemaining / 60);
        float seconds = Mathf.FloorToInt(Timer.TimeRemaining % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
