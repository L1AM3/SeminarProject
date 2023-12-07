using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    [Header("Music Clips")]
    public AudioClip MenuMusic;
    public AudioClip Level1Music;
    public AudioClip Level2Music;
    public AudioClip Level3Music;
    public AudioClip LoseMenuMusic;
    public AudioClip WinMenuMusic;

    [Header("Audio Source")]
    public AudioSource MusicPlayer;


    public void MenuBGM()
    {
        if (MusicPlayer != null)
        {
            if(MusicPlayer.clip != MenuMusic)
            {
                MusicPlayer.Stop();
                MusicPlayer.clip = MenuMusic;
                MusicPlayer.Play();
            }
        }
    }

    public void LevelOneBGM()
    {
        if (MusicPlayer != null)
        {
            if (MusicPlayer.clip != Level1Music)
            {
                MusicPlayer.Stop();
                MusicPlayer.clip = Level1Music;
                MusicPlayer.Play();
            }
        }
    }

    public void LevelTwoBGM()
    {
        if (MusicPlayer != null)
        {
            if (MusicPlayer.clip != Level2Music)
            {
                MusicPlayer.Stop();
                MusicPlayer.clip = Level2Music;
                MusicPlayer.Play();
            }
        }
    }

    public void LevelThreeBGM()
    {
        if (MusicPlayer != null)
        {
            if (MusicPlayer.clip != Level3Music)
            {
                MusicPlayer.Stop();
                MusicPlayer.clip = Level3Music;
                MusicPlayer.Play();
            }
        }
    }

    public void LoseMenuBGM()
    {
        if (MusicPlayer != null)
        {
            if (MusicPlayer.clip != LoseMenuMusic)
            {
                MusicPlayer.Stop();
                MusicPlayer.clip = LoseMenuMusic;
                MusicPlayer.Play();
            }
        }
    }

    public void WinMenuBGM()
    {
        if (MusicPlayer != null)
        {
            if (MusicPlayer.clip != WinMenuMusic)
            {
                MusicPlayer.Stop();
                MusicPlayer.clip = WinMenuMusic;
                MusicPlayer.Play();
            }
        }
    }
}
