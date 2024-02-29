using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{

    public string groundTag = "Floor";
    public Vector3 direction;
    public float jumpForce = 5.0f; // Siła skoku

    private Rigidbody rb;
    private bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 0.55f))
        {
            if (hit.transform.CompareTag(groundTag))
            {
                isGrounded = true; // Ustaw stan jako na ziemi
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
