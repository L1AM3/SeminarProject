using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void MathMenu()
    {
        SceneManager.LoadScene("MathMenu");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("BattleField");
    }
}