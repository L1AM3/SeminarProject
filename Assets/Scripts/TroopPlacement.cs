using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TroopPlacement : MonoBehaviour
{
    public TroopData troopData;

    private void Awake()
    {
        troopData.TakeDamage(3);
    }
}
