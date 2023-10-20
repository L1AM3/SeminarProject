using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TroopManager
{
    public static event Action TroopMoved;
    //private List<TroopBehavior> _behaviors;

    public static void Invoke()
    {
        TroopMoved?.Invoke();
    }

}
