using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathSolvingTimer : MonoBehaviour
{
    private void Update()
    {
        Timer.Timing(Time.deltaTime);
    }
}
