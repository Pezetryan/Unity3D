using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public enum Sounds
    {

        Bonus, Win, Lose

    }


    public AudioClip bonusAudio;
    public AudioClip winAudio;
    public AudioClip loseAudio;


    AudioSource audioSource;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("SoundManager").Length > 1) 
        {
            Destroy(this.gameObject);
        
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound(Sounds sound)
    {
        switch (sound) 
        {
            case Sounds.Bonus:
                audioSource.PlayOneShot(bonusAudio);
                break;
            case Sounds.Win:
                audioSource.PlayOneShot(winAudio);
                break;
            case Sounds.Lose:
                audioSource.PlayOneShot(loseAudio);
                break;


            default: 
                break;
        
        }
        
    }

    
}
