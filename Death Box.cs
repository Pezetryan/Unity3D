using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{

    SoundManager soundManager;
    AudioSource audioSource;
    public bool isRigidbody = false;
    Rigidbody rb;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

        if (isRigidbody)
        {

            rb = gameObject.AddComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rb.mass = 0.75f;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            RestartLvl();


        }
    }

    public void RestartLvl()
    {
        soundManager.PlaySound(SoundManager.Sounds.Lose);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

}
