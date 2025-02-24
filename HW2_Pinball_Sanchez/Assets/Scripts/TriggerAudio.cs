using Unity.VisualScripting;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hey");
        if (other.CompareTag("Player")){
            audioSource.Play();
            
        }
    }
}
