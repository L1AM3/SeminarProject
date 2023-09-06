using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathProblemGenerator : MonoBehaviour
{
    private int randomNumberOne;
    private int randomNumberTwo;

    public string[] randomSymbol;
    private int symbolIndex;

    public TMP_Text numOne;
    public TMP_Text numTwo;
    public TMP_Text symbol;
    

    // Start is called before the first frame update
    void Start()
    {
        randomNumberOne = UnityEngine.Random.Range(0, 30);
        randomNumberTwo = UnityEngine.Random.Range(0, 30);
        symbolIndex = UnityEngine.Random.Range(0, randomSymbol.Length - 1);

        numOne.SetText(randomNumberOne.ToString());
        numTwo.SetText(randomNumberTwo.ToString());
        symbol.SetText(randomSymbol[symbolIndex].ToString());

        Debug.Log(randomNumberOne + randomSymbol[symbolIndex] + randomNumberTwo);
        Debug.Log(GetOperationsAnswersString());
    }

    public string GetOperationsAnswersString()
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

    public string MixedNumberFraction()
    {
        int wholeNumber = randomNumberOne / randomNumberTwo;
        int remainder = randomNumberOne % randomNumberTwo;
        string mixedNum = wholeNumber.ToString() + " " + remainder.ToString() + "/" + randomNumberTwo.ToString();

        return mixedNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
