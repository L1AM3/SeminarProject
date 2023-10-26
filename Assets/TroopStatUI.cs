using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TroopStatUI : MonoBehaviour
{
    public TroopBehavior TroopInformation;

    public TMP_Text TroopHealthTxt;
    public TMP_Text TroopDamageTxt;
    public TMP_Text TroopMovesTxt;

    // Update is called once per frame
    void Update()
    {
        TroopHealthTxt.text = TroopInformation.TroopInfo.Health.ToString();
        TroopDamageTxt.text = TroopInformation.TroopInfo.Damage.ToString();
        TroopMovesTxt.text = (TroopInformation.TroopInfo.Movement - TroopInformation.currentMoveCount).ToString();
    }
}
