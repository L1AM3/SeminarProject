using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeRemaining = 2;

    public TMP_Text Time; 

    public bool IsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        IsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= TimeRemaining;
            }
            else
            {
                Debug.Log("Time has run out!");
                TimeRemaining = 0;
                IsRunning = false;
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
