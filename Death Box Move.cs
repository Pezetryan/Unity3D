using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DeathBoxMove : MonoBehaviour
{
    //cześc odpowiedzilan za jeżdzeie
    public Vector3 direction;
    public float speed;
    Vector3 force;
    public bool reverse = false;
    //część odpowiedzla na smierc
    SoundManager soundManager;
    AudioSource audioSource;
    public bool isRigidbody = false;
    Rigidbody rb;


    void Start()
    {
        //jezdzenie
        force = Vector3.left * speed;

        if (reverse)
        {

            ReverseVectors();

        }


        //smierc

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

    //jezdzenie
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, direction, Color.red, 0.1f, false);

        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.CompareTag("Floor") || hit.transform.gameObject.CompareTag("Player"))
            {

                Move();

            }
            else
            {
                ReverseVectors();

            }
        }
        else
        {
            ReverseVectors();
        }
    }

    void Move()
    {
        //transform.GetComponent<Rigidbody>().AddForce(force);
        transform.GetComponent<Rigidbody>().velocity = force;
    } 

    void ReverseVectors()
    {

        force = -force;
        direction.Set(-direction.x, direction.y, direction.z);

    }

    //smierc
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
