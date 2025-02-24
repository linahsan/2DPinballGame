using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoundReload : MonoBehaviour
{
    [SerializeField] private int attemptsLeft = 3;
    [SerializeField] private GameObject player;
    [SerializeField] private float roundTimer = 15f;
    [SerializeField] private TextMeshProUGUI  timerText; 
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] int score;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    
    void Update()
    {
        UpdateText();
        Debug.Log(score);
        roundTimer -= Time.deltaTime;
        if (player == null || roundTimer <= 0)
        {
            ReloadScene();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hello");
        if (other.CompareTag("Win"))
        {
            score++;
            ReloadScene();
        }
        else if (other.CompareTag("Lose"))
        {
            ReloadScene();
        }
    }

    void UpdateText()
    {
        timerText.text = "Time: " + Mathf.Max(0, Mathf.FloorToInt(roundTimer));
        scoreText.text = "Score: " + score; 
        Debug.Log(score);
        Canvas.ForceUpdateCanvases();
    }

    void ReloadScene()
    {
        if (attemptsLeft > 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            attemptsLeft--;
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
}
