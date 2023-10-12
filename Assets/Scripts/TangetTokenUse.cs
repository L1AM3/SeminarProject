using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TangetTokenUse : MonoBehaviour
{
    [SerializeField] private TMP_Text tangenttokentext;
    [SerializeField] private GameObject mathMenuObj;
    private int tangetTokenCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        mathMenuObj.SetActive(false);
    }

    public void TangetTokenActivation()
    {
        if (tangetTokenCount >= 1) 
        {
            Time.timeScale = 0;
            tangetTokenCount--;
            mathMenuObj.SetActive(true);
        }
    }

    public void TangetButton()
    {
        mathMenuObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tangenttokentext.text = tangetTokenCount.ToString();
        //if (Timer.IsRunning == false)
        //{
            //mathMenuObj.SetActive(false);
        //}
    }
}
