using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplatform1 : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    Vector3 force;
    public bool reverse = false;

    void Start()
    {
        force = Vector3.forward * speed;

        if (reverse)
        {
            ReverseVectors();
        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, direction, Color.red, 0.1f, false);

        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
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
        transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, force.z);
    }

    void ReverseVectors()
    {
        force = -force;
        direction.Set(direction.x, direction.y, -direction.z);
    }
}