using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject TroopTypePanel;
    [SerializeField] private GameObject TroopMovePlacePanel;
    [SerializeField] private GameObject TroopStackTurnControlPanel;
    [SerializeField] private GameObject TroopEnemyCombatPanel;
    [SerializeField] private GameObject TilesObjectivesPanel;
    [SerializeField] private GameObject TutorialEndPanel;

    // Start is called before the first frame update
    void Start()
    {
        TroopTypePanel.SetActive(true);
        TroopMovePlacePanel.SetActive(false);
        TroopStackTurnControlPanel.SetActive(false);
        TroopEnemyCombatPanel.SetActive(false);
        TilesObjectivesPanel.SetActive(false);
        TutorialEndPanel.SetActive(false);
    }

    public void PanelOne()
    {
        TroopTypePanel.SetActive(false);
        TroopMovePlacePanel.SetActive(true);
    }

    public void PanelTwo()
    {
        TroopMovePlacePanel.SetActive(false);
        TroopStackTurnControlPanel.SetActive(true);
    }

    public void PanelThree()
    {
        TroopStackTurnControlPanel.SetActive(false);
        TroopEnemyCombatPanel.SetActive(true);
    }

    public void PanelFour()
    {
        TroopEnemyCombatPanel.SetActive(false);
        TilesObjectivesPanel.SetActive(true);
    }

    public void PanelFive()
    {
        TilesObjectivesPanel.SetActive(false);
        TutorialEndPanel.SetActive(true);
    }
}
