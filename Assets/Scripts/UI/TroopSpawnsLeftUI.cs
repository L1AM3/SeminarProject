using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TroopSpawnsLeftUI : MonoBehaviour
{
    public TroopPlacement Place;
    public TMP_Text LeftOver;

    // Update is called once per frame
    void Update()
    {
        LeftOver.text = Place.GetSpawnsLeft().ToString();
    }
}
