using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int EnemyBaseHealth;
    public int HomeBaseHealth;

    private void Awake()
    {
        //Singleton garbage
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        //Singleton garbage done

    }

    [SerializeField] private bool isTroopPlacing = true;

    public bool IsTroopPlacing() => isTroopPlacing;
    public void SetIsTroopPlacing(bool isTroopPlacingTurn) => isTroopPlacing = isTroopPlacingTurn;

    


}
