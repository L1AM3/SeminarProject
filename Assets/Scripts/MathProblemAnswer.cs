using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathProblemAnswer : MonoBehaviour
{
    public MathProblemUI UI;

    public TMP_Text input;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CompareInput();
        }
    }

    public void CompareInput()
    {
        string playerInput = input.text;
        Debug.Log(playerInput);
        Debug.Log(input.text);

        string answer = MathProblemGenerator.GetOperationsAnswersString();

        if (playerInput.Contains(answer))
        {
            TroopManager.TroopAdder();
            MathProblemGenerator.GenerateMathProblem();
            UI.ClearInput();
            
        }
        else
        {
            UI.ClearInput();
        }
    }

}
