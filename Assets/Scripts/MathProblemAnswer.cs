using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathProblemAnswer : MonoBehaviour
{
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
        Debug.Log("test");
        if (playerInput.Equals(MathProblemGenerator.GetOperationsAnswersString()))
        {
            Debug.Log("yippe");
        }
        else
        {
            Debug.Log("notyippe");
        }

    }

}
