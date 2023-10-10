using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject/TroopType")]
public class TroopScriptableObject : ScriptableObject
{
    public int health;

    public TroopScriptableObject(TroopScriptableObject obj)
    {
        health = obj.health;
    }
}
