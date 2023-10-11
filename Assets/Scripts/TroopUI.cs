using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopUI : MonoBehaviour
{
    [SerializeField] TroopPlacement placement;
    [SerializeField] int TroopType;

    public void SetPlacementType()
    {
        placement.SetType(TroopType);
    }
}
