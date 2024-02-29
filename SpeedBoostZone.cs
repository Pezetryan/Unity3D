using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{
    public float boostForce = 10.0f; // Siła przyspieszenia
    public string playerTag = "Player"; // Tag gracza

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdź, czy obiekt wchodzący w obszar triggrowy ma odpowiedni tag (np. "Ball")
        if (other.CompareTag(playerTag))
        {
            Rigidbody ballRigidbody = other.GetComponent<Rigidbody>();

            // Jeśli obiekt ma komponent Rigidbody (np. piłka), dodaj siłę przyspieszenia
            if (ballRigidbody != null)
            {
                ballRigidbody.AddForce(transform.forward * boostForce, ForceMode.Impulse);
            }
        }
    }
}
