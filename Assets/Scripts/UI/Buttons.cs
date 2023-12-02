using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
/*    public void MathMenu()
    {
        SceneManager.LoadScene("MathMenu");
    }*/

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("BattleField");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("BattleField 2");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("BattleField 3");
    }


}
