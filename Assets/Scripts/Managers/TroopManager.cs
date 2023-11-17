using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class TroopManager
{
    public static List<TroopBehavior> troops = new();
    public static event Action TroopMoved;
    public static event Action TroopSpawned;
    public static event Action TroopTurnFinished;
    //private List<TroopBehavior> _behaviors;

    public static void InvokeTroopMove(TroopBehavior troop)
    {
        TroopMoved?.Invoke();
    }

    public static void InvokeTroopSpawned(TroopBehavior troop)
    {
        troops.Add(troop);
        TroopSpawned?.Invoke();
    }

    public static bool RemoveTroop(TroopBehavior troop)
    {
        return troops.Remove(troop);
    }

    public static void InvokeTroopTurnFinished()
    {
        TroopTurnFinished?.Invoke();
    }

    public static void SetSelectedTroop(TroopBehavior troop)
    {
        foreach(var t in troops)
        {
            t.IsTroopSelected = false;
        }

        troop.IsTroopSelected = true;
    }
}