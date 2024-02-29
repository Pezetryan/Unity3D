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
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
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

}
