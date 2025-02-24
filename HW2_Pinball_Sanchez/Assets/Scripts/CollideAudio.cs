using System;
using UnityEngine;

public class CollideAudio : MonoBehaviour
{
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hey");
        if (other.gameObject.CompareTag("Player")){
            audioSource.Play();
            
        }
    }
}
