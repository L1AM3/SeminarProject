using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathSelection : MonoBehaviour
{
    public void AdditionButton()
    {
        MathProblemGenerator.symbolIndex = 0;
        MathProblemGenerator.GenerateMathProblem();
        SceneManager.LoadScene("MathSolving");
    }

    public void SubtractionButton()
    {
        MathProblemGenerator.symbolIndex = 1;
        MathProblemGenerator.GenerateMathProblem();
        SceneManager.LoadScene("MathSolving");
    }

    public void MultiplicationButton()
    {
        MathProblemGenerator.symbolIndex = 2;
        MathProblemGenerator.GenerateMathProblem();
        SceneManager.LoadScene("MathSolving");
    }

    public void DivisionButton()
    {
        MathProblemGenerator.symbolIndex = 3;
        MathProblemGenerator.GenerateMathProblem();
        SceneManager.LoadScene("MathSolving");
    }

    public void SceneAdditionButton()
    {
        MathProblemGenerator.symbolIndex = 0;
        MathProblemGenerator.GenerateMathProblem();
    }

    public void SceneSubtractionButton()
    {
        MathProblemGenerator.symbolIndex = 1;
        MathProblemGenerator.GenerateMathProblem();
    }

    public void SceneMultiplicationButton()
    {
        MathProblemGenerator.symbolIndex = 2;
        MathProblemGenerator.GenerateMathProblem();
    }

    public void SceneDivisionButton()
    {
        MathProblemGenerator.symbolIndex = 3;
        MathProblemGenerator.GenerateMathProblem();
    }
}
