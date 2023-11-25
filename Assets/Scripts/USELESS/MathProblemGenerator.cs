/*using System;
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
        randomNumberOne = UnityEngine.Random.Range(1, 12);
        randomNumberTwo = UnityEngine.Random.Range(1, 12);

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
        int gcd = GetGreatestCommonDivisor(randomNumberOne, randomNumberTwo);

        if (gcd != -1)
        {
            randomNumberOne /= gcd;
            randomNumberTwo /= gcd;
        }

        string mixedNum;
        int wholeNumber = randomNumberOne / randomNumberTwo;
        int remainder = randomNumberOne % randomNumberTwo;

        if (remainder == 0)
        {
            return wholeNumber.ToString();
        }

        if (wholeNumber == 0)
        {
            mixedNum = remainder.ToString() + "/" + randomNumberTwo.ToString();
            return mixedNum;
        }

        mixedNum = wholeNumber.ToString() + " " + remainder.ToString() + "/" + randomNumberTwo.ToString();

        return mixedNum;
    }

    public static int GetGreatestCommonDivisor(int num, int dom)
    {
        for (int i = num; i >= 1; i--)
        {
            if (num % i == 0 && dom % i == 0)
            {
                return i;
            }
        }
        return -1;
    }
}
*/