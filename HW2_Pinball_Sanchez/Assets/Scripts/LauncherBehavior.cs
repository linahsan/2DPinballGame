using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LauncherBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody2D ball;
    [SerializeField] float chargeAmount = 0f;
    [SerializeField] float maxCharge = 20f;
    [SerializeField] bool isTouching = false;
    [SerializeField] private BallMovement ballMovement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballMovement = GameObject.FindAnyObjectByType<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isTouching)
        {
            chargeAmount += Time.deltaTime * 10;
            chargeAmount = Mathf.Clamp(chargeAmount, 0, maxCharge);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && isTouching)
        {
            Debug.Log("launch!");
            ballMovement.LaunchSelf();
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        ball.linearVelocity = Vector2.zero;
        ball.AddForce(Vector2.up * chargeAmount, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GameObject() == ball.GameObject())
        {
            Debug.Log("touching");
            isTouching = true;
            ballMovement.StopSelf();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GameObject() == ball.GameObject())
        {
            Debug.Log("not touching");
            isTouching = false;
        }
        
    }
}
