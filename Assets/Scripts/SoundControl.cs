using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public GameObject WinSound;
  
    public GameObject BattleMusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.2f;

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void PlayHitSound()
    {
        
        audioSource.clip = hitSound;
        audioSource.Play();
    }

   
    public void PlayDeathSound()
    {
        
        audioSource.clip = deathSound;
        audioSource.Play();
    }

    public void PlayWinSound()
    {
        WinSound.SetActive(true);
    }
    

}
