using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Clips")]
    public AudioClip ButtonPress;
    public AudioClip DamageBase;
    public AudioClip DamageTroop;
    public AudioClip DamageEnemy;
    public AudioClip Move;
    public AudioClip Select;

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
            Clicking.PlayOneShot(ButtonPress, 1.0f);
        }
    }

    public void SelectSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(Select, 1.0f);
        }
    }

    public void MoveSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(Move, 1.0f);
        }
    }

    public void DamageTroopSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(DamageTroop, 1.0f);
        }
    }

    public void DamageEnemySFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(DamageEnemy, 1.0f);
        }
    }

    public void DamageBaseSFX()
    {
        if (Clicking != null)
        {
            Clicking.PlayOneShot(DamageBase, 1.0f);
        }
    }
}
