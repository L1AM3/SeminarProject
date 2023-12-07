using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneMusicPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.instance.LevelOneBGM();
    }
}
