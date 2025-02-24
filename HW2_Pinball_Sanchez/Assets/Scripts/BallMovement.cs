using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopSelf()
    {
        Debug.Log("stopping");
        rigidBody.linearVelocity = new Vector2(0, 0);
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void LaunchSelf()
    {
        Debug.Log("launching");
        rigidBody.constraints = RigidbodyConstraints2D.None;
    }


}
