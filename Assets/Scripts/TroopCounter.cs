using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public static class TroopCounter
{
    public static int AdditionArcher;
    public static int SubtractionSwordsman;
    public static int MultiplicationMarine;
    public static int DivisionDogFighter;

    public static void TroopAdder()
    {
        if (MathProblemGenerator.symbolIndex == 0)
        {
            AdditionArcher++;
            Debug.Log("Archer: " +  AdditionArcher);
        }
        else if (MathProblemGenerator.symbolIndex == 1)
        {
            SubtractionSwordsman++;
            Debug.Log("Sword: " + SubtractionSwordsman);
        }
        else if (MathProblemGenerator.symbolIndex == 2)
        {
            MultiplicationMarine++;
            Debug.Log("Marine: " + MultiplicationMarine);
        }
        else if (MathProblemGenerator.symbolIndex == 3)
        {
            DivisionDogFighter++;
            Debug.Log("DogFighter: " + DivisionDogFighter);
        }
    }
}
