using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenuMusicPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.instance.WinMenuBGM();
    }
}
