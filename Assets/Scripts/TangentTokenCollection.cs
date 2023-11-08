using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangentTokenCollection : MonoBehaviour
{
    public TangetTokenUse TokenCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Troop")
        {
            TokenCount.TangentTokenAdd();
            Destroy(this);
        }
    }

}
