using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TroopData
{
    public int Health;
    public int Damage;
    public int MoveSpeed;

    public void TakeDamage(int damage)
    { Health -= damage; }
}
