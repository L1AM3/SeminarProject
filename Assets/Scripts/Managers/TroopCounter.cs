using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class TroopCounter: MonoBehaviour
{
    public static TroopCounter Instance;

    private void Awake()
    {
        //Singleton garbage
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        //Singleton garbage done

    }

    public int AdditionArcher = 20;
    public int SubtractionSwordsman = 20;
    public int MultiplicationMarine = 20;
    public int DivisionDogFighter = 20;

    public void AddArcher()
    {
        AdditionArcher++;
    }

    public void AddSwordsman()
    {
        SubtractionSwordsman++;
    }

    public void AddMarine()
    {
        MultiplicationMarine++;
    }

    public void AddDogFighter()
    {
        DivisionDogFighter++;
    }

   /* public static void TroopAdder()
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
    }*/
}
