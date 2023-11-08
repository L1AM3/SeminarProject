using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopUI : MonoBehaviour
{
    [SerializeField] TroopPlacement placement;
    [SerializeField] TroopType TroopType;

    public void SetPlacementType()
    {
        placement.SetType(TroopType);
    }
}
