using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathProblemAnswer : MonoBehaviour
{
    public MathProblemUI UI;

    public TMP_InputField input;

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

        if (playerInput.Equals(MathProblemGenerator.GetOperationsAnswersString()))
        {
            TroopManager.TroopAdder();
            MathProblemGenerator.GenerateMathProblem();
            
        }
        else
        {
            //Debug.Log("notyippe");
        }
    }

}
