using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BallBoost : MonoBehaviour
{
    [SerializeField]
    float boostForce = 1f;

    GameObject boostText;
    Rigidbody rb;
    bool boostActivated = false;
    bool boostReady = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boostText = GameObject.Find("Boost Text").gameObject;
        TextVisible();

    }



    void Update()
    {
        //Debug.Log(rb.velocity.normalized);
        TextVisible();

        if (Input.GetKeyDown(KeyCode.LeftAlt) && boostReady && rb.velocity != Vector3.zero)
        {
            boostActivated = true;
            boostReady = false;
        }
    }

    private void FixedUpdate()
    {
        if (boostActivated)
        {

            rb.AddForce(rb.velocity.normalized * boostForce, ForceMode.Impulse);
            boostActivated = false;
            StartCoroutine("BoostCoroutine"); //tak wywołujenmy korutyny


        }
    }

    IEnumerator BoostCoroutine() //KORUTYNA
    {
        yield return new WaitForSeconds(3f); 
        boostReady = true;
        yield break;
    }

    private void TextVisible()
    {
        if (boostReady)
        {
            boostText.SetActive(true);
        }
        else
        {
            boostText.SetActive(false);
        }
    }
}
