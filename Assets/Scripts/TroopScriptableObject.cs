using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject/TroopType")]
public class TroopScriptableObject : ScriptableObject
{
    public int HitsCanTake;
    public int Damage;
    public int Defense;
    public int Movement;
    public int Range;


    public TroopScriptableObject(TroopScriptableObject obj)
    {
        HitsCanTake = obj.HitsCanTake;
    }
}
