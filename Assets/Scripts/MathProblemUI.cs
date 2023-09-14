using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathProblemUI : MonoBehaviour
{
    public TMP_Text MathProblem;

    private void UpdateUI()
    {
       MathProblem.text = MathProblemGenerator.MathProblem;
    }
}
