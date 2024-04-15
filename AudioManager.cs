using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip mainMenuMusic;
    public AudioClip levelMusicW1;
    public AudioClip levelMusicW2;
    public AudioClip levelMusicW3;


    private AudioSource audioSource;

    // Zapamiętaj nazwę aktualnie odtwarzanego utworu muzycznego
    private string currentMusicName;
    // Zapamiętaj bieżący czas odtwarzania utworu muzycznego
    private float currentTime;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMainMenuMusic()
    {
        // Ustaw nazwę i czas odtwarzania utworu muzycznego
        currentMusicName = "MainMenu";
        audioSource.clip = mainMenuMusic;
        audioSource.time = currentTime; // Ustaw bieżący czas odtwarzania
        audioSource.Play();
    }

    public void PlayLevelW1Music()
    {
        currentMusicName = "LevelW1";
        audioSource.clip = levelMusicW1;
        audioSource.time = currentTime; // Ustaw bieżący czas odtwarzania
        audioSource.Play();
    }

    public void PlayLevelW2Music()
    {
        currentMusicName = "LevelW2";
        audioSource.clip = levelMusicW2;
        audioSource.time = currentTime; // Ustaw bieżący czas odtwarzania
        audioSource.Play();
    }

    public void PlayLevelW3Music()
    {
        currentMusicName = "LevelW3";
        audioSource.clip = levelMusicW3;
        audioSource.time = currentTime; // Ustaw bieżący czas odtwarzania
        audioSource.Play();
    }

    // Zapisz bieżący czas odtwarzania i nazwę utworu muzycznego przed przejściem do innej sceny
    public void SaveMusicState()
    {
        currentTime = audioSource.time;
    }

    // Przy ponownym załadowaniu tej samej sceny, wznowienie odtwarzania muzyki
    public void ResumeMusic()
    {
        if (currentMusicName == "MainMenu")
            PlayMainMenuMusic();
        else if (currentMusicName == "LevelW1")
            PlayLevelW1Music();
        else if (currentMusicName == "LevelW2")
            PlayLevelW2Music();
        else if (currentMusicName == "LevelW3")
            PlayLevelW3Music();
        
    }
}

