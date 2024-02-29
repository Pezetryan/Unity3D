using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sppherconbtro : MonoBehaviour
{
    [Header("Control Setting")]
    [SerializeField]
    private float speed = 1.0f;
    public float maxAngularVelocity;


    private Rigidbody rb;
    private bool isRigidbody;

    private GameManager gameManager;

    void Start()
    {


        if (isRigidbody = TryGetComponent<Rigidbody>(out rb))
        {
            rb.maxAngularVelocity = maxAngularVelocity;
        }

        //gameManager = GameObject.FindObjectOfType<GameManager>(); //ku pamieci
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

    }

    private void Update()
    {
        if (transform.position.y < -10f) 
        {
            gameManager.RestartLvl();        
        }
    }


    private void FixedUpdate()
    {

        float Hdirection;
        float Vdirection;



        if (isRigidbody && (Hdirection = Input.GetAxis("Horizontal")) != 0)
        {

            rb.AddTorque(0, 0, -Hdirection * speed * Time.fixedDeltaTime);

        }
        if (isRigidbody && (Vdirection = Input.GetAxis("Vertical")) != 0)
        {

            rb.AddTorque(Vdirection * speed * Time.fixedDeltaTime, 0, 0);

        }

    }

}
