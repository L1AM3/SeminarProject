using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
     
    }

    [Header("Audio Clips")]
    public AudioClip ButtonPress;
    public AudioClip DamageBase;
    public AudioClip DamageTroop;
    public AudioClip DamageEnemy;
    public AudioClip Move;
    public AudioClip Select;
    public AudioClip TroopSpawn;
    public AudioClip EnemySpawn;

    //[Header("Audio Sources")]
    public AudioSource Clicking;
    /*public AudioSource Movement;
    public AudioSource TroopDamage;
    public AudioSource EnemyDamage;
    public AudioSource BaseDamage;*/

    public void ButtonPressSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(ButtonPress, 0.1f);
        }
    }

    public void SelectSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(Select, 0.25f);
        }
    }

    public void MoveSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(Move, 0.25f);
        }
    }

    public void DamageTroopSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(DamageTroop, 0.25f);
        }
    }

    public void DamageEnemySFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(DamageEnemy, 0.25f);
        }
    }

    public void DamageBaseSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(DamageBase, 0.5f);
        }
    }

    public void EnemySpawnSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(EnemySpawn, 0.15f);
        }
    }

    public void TroopSpawnSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(TroopSpawn, 0.15f);
        }
    }
}
