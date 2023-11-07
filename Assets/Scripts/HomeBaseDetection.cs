using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBaseDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject theObject = collision.gameObject;

        if (theObject.CompareTag("Enemy"))
        {

        }
    }
}
