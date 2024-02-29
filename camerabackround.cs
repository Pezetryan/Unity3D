using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTexture : MonoBehaviour
{
    public Texture2D backgroundTexture;

    void Start()
    {
        if (backgroundTexture != null)
        {
            // Sprawdź czy komponent Renderer jest dostępny
            Renderer renderer = GetComponent<Renderer>();

            if (renderer != null)
            {
                // Tworzymy nowy materiał z teksturą
                Material material = new Material(Shader.Find("Standard"));
                material.mainTexture = backgroundTexture;

                // Przypisujemy materiał do komponentu Renderer
                renderer.material = material;
            }
            else
            {
                Debug.LogError("Komponent Renderer nie jest dostępny.");
            }
        }
        else
        {
            Debug.LogError("Tekstura tła nie jest przypisana.");
        }
    }
}