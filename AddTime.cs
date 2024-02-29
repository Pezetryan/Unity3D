using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddTime : MonoBehaviour
{

    public float timeToAdd = 5f;
    public GameObject bonusParticlr;
    SoundManager soundManager;
    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            soundManager.PlaySound(SoundManager.Sounds.Bonus);
            gm.time += timeToAdd;
            Instantiate(bonusParticlr, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }


}
