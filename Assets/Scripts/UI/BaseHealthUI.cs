using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BaseHealthUI : MonoBehaviour
{
    public TMP_Text EBaseH;
    public TMP_Text HBaseH;
    private bool EnemyBaseOuch = false;
    private bool HomeBaseOuch = false;
    private float fontSize;

    private void Start()
    {
        EBaseH.text = GameManager.Instance.GetEnemyBaseHealth().ToString();
        HBaseH.text = GameManager.Instance.GetHomeBaseHealth().ToString();

        GameManager.Instance.HomeBaseDamaged += HomeDamageFeedback;
        GameManager.Instance.EnemyBaseDamaged += EnemyDamageFeedback;

        fontSize = EBaseH.fontSize;
    }

    private void Update()
    {
        if (EnemyBaseOuch)
        {
            EBaseH.fontSize = Mathf.Lerp(EBaseH.fontSize, fontSize, 5 * Time.deltaTime);

            if(EBaseH.fontSize - fontSize <= 0.5f)
            {
                EBaseH.color = Color.white;
                EBaseH.fontSize = fontSize;
                EnemyBaseOuch = false;

            }
        }

        if (HomeBaseOuch)
        {
            HBaseH.fontSize = Mathf.Lerp(HBaseH.fontSize, fontSize, 5 * Time.deltaTime);

            if (HBaseH.fontSize - fontSize <= 0.5f)
            {
                HBaseH.color = Color.white;
                HBaseH.fontSize = fontSize;
                HomeBaseOuch = false;
            }
        }
    }

    private void EnemyDamageFeedback(int obj)
    {
        EBaseH.text = GameManager.Instance.GetEnemyBaseHealth().ToString();

        EBaseH.color = Color.red; EBaseH.fontSize += 20;
        EnemyBaseOuch = true;
    }

    public void HomeDamageFeedback(int damage)
    {
        HBaseH.text = GameManager.Instance.GetHomeBaseHealth().ToString();

        HBaseH.color = Color.red; HBaseH.fontSize += 20;
        HomeBaseOuch = true;
    }
}
