using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Ball Settings")]
    public GameObject ballPrefab;
    public Transform startPosition;
    [Header("Time Settings")]
    public TextMeshProUGUI timeText;
    public float time;
    public float slowTimeSeconds;
    public float slowTimeAmunt;

    SoundManager soundManager;
    AudioSource audioSource;

    private void Awake()
    {
        Instantiate(ballPrefab, startPosition.position, Quaternion.identity);
    }

    private void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

       
        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3" || SceneManager.GetActiveScene().name == "Level 4" || SceneManager.GetActiveScene().name == "Level 5" || SceneManager.GetActiveScene().name == "Level 6" || SceneManager.GetActiveScene().name == "Level 7" || SceneManager.GetActiveScene().name == "Level 8" || SceneManager.GetActiveScene().name == "Level 9")
        {
            AudioManager.instance.SaveMusicState();
            AudioManager.instance.PlayLevelW1Music();
        }
        else if (SceneManager.GetActiveScene().name == "Level 10" || SceneManager.GetActiveScene().name == "Level 11" || SceneManager.GetActiveScene().name == "Level 12" || SceneManager.GetActiveScene().name == "Level 13" || SceneManager.GetActiveScene().name == "Level 14" || SceneManager.GetActiveScene().name == "Level 15" || SceneManager.GetActiveScene().name == "Level 16" || SceneManager.GetActiveScene().name == "Level 17" || SceneManager.GetActiveScene().name == "Level 18")
        {
            AudioManager.instance.SaveMusicState();
            AudioManager.instance.PlayLevelW2Music();
        }
        else if (SceneManager.GetActiveScene().name == "Level 19" || SceneManager.GetActiveScene().name == "Level 20" || SceneManager.GetActiveScene().name == "Level 21" || SceneManager.GetActiveScene().name == "Level 22" || SceneManager.GetActiveScene().name == "Level 23" || SceneManager.GetActiveScene().name == "Level 24" || SceneManager.GetActiveScene().name == "Level 25" || SceneManager.GetActiveScene().name == "Level 26" || SceneManager.GetActiveScene().name == "Level 27")
        {
            AudioManager.instance.SaveMusicState();
            AudioManager.instance.PlayLevelW3Music();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 11 || SceneManager.GetActiveScene().buildIndex == 21 || SceneManager.GetActiveScene().buildIndex == 31)
        {
            AudioManager.instance.PlayMainMenuMusic();
        }
        // Dodaj warunki dla innych scen, jeśli jest to konieczne
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            AudioManager.instance.PlayMainMenuMusic();

        }
        time -= Time.deltaTime;

        timeText.text = "Time: " + Mathf.Clamp(Mathf.CeilToInt(time), 0, int.MaxValue).ToString();

        if (time <= 0)
        {
            RestartLvl();

        }
        if (Time.timeScale >= 1f && time <= slowTimeSeconds)
        {
            //SLOW SPEED
            Time.timeScale = slowTimeAmunt;
            timeText.enableVertexGradient = false;
            timeText.color = new Color(1f, 0f, 0f);
            audioSource.Play();
        }
        else if (Time.timeScale < 1f && time > slowTimeSeconds) 
        {
            //NORMAL SPEED
            Time.timeScale = 1f;
            timeText.enableVertexGradient = true;
            timeText.color = new Color(1f, 1f, 1f);
            audioSource.Stop();


        }
    }

    public void RestartLvl()
    {
        soundManager.PlaySound(SoundManager.Sounds.Lose);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }

    public void NextLevel()
    {

        soundManager.PlaySound(SoundManager.Sounds.Win);

        int activeScene = SceneManager.GetActiveScene().buildIndex;

        if (PlayerPrefs.GetInt("level", 1) < activeScene + 1) 
        {
            PlayerPrefs.SetInt("level", activeScene + 1);
        }


        if (SceneManager.sceneCountInBuildSettings > (activeScene + 1))
        {
            SceneManager.LoadScene(activeScene + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioManager.instance.ResumeMusic();
    }

}
