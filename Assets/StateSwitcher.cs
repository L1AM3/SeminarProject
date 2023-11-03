using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateSwitcher : MonoBehaviour
{
    public Button PlacementButton;
    public Button MovementButton;
    public Button EndTurn;

    public void EndPlacementPhase()
    {
        GameManager.Instance.SetIsTroopPlacing(false);
        PlacementButton.gameObject.SetActive(false);
        MovementButton.gameObject.SetActive(true);
    }

    public void EndMovementPhase()
    {
        EndTurn.gameObject.SetActive(true);
        MovementButton.gameObject.SetActive(false);
    }
}
