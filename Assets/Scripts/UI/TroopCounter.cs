using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public static class TroopCounter
{
    //5 is test num set it back to 0 idiot
    public static int AdditionArcher = 20;
    public static int SubtractionSwordsman = 20;
    public static int MultiplicationMarine = 20;
    public static int DivisionDogFighter = 20;

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
