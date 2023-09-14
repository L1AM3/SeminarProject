using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class MathProblemGenerator
{
    private static int randomNumberOne;
    private static int randomNumberTwo;

    public static string[] randomSymbol = { " + ", " - ", " * ", " / " };

    public static int symbolIndex;

    public static string MathProblem;

    public static void GenerateMathProblem()
    {
        randomNumberOne = UnityEngine.Random.Range(0, 30);
        randomNumberTwo = UnityEngine.Random.Range(0, 30);

        MathProblem = (randomNumberOne.ToString());
        MathProblem += (randomSymbol[symbolIndex].ToString());
        MathProblem += (randomNumberTwo.ToString());

        Debug.Log(randomNumberOne + randomSymbol[symbolIndex] + randomNumberTwo);
        Debug.Log(GetOperationsAnswersString());
    }

    public static string GetOperationsAnswersString()
    {
        if (symbolIndex == 0)
        {
            return (randomNumberOne + randomNumberTwo).ToString();
        }

        if (symbolIndex == 1)
        {
            return (randomNumberOne - randomNumberTwo).ToString();
        }

        if (symbolIndex == 2)
        {
            return (randomNumberOne * randomNumberTwo).ToString();
        }

        if (symbolIndex == 3)
        {
            return MixedNumberFraction();
        }

        return "";
    }

    public static string MixedNumberFraction()
    {
        string mixedNum;
        int wholeNumber = randomNumberOne / randomNumberTwo;
        int remainder = randomNumberOne % randomNumberTwo;

        if (wholeNumber == 0)
        {
            mixedNum = remainder.ToString() + "/" + randomNumberTwo.ToString();
            return mixedNum;
        }

        mixedNum = wholeNumber.ToString() + " " + remainder.ToString() + "/" + randomNumberTwo.ToString();

        return mixedNum;
    }

}
