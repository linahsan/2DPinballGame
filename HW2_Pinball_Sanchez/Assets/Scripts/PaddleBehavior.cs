using Unity.VisualScripting;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] private float spinSpeed = 1f;
    [SerializeField] private float stopAngleOpen = 50f;
    [SerializeField] private float stopAngleClose = 0f;
    [SerializeField] Rigidbody2D ball;
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
       
        
    }
    void FixedUpdate()
    {
        float currentAngle = transform.rotation.eulerAngles.z;

        if (Input.GetMouseButton(0))
        {
            if (currentAngle < stopAngleOpen)
            {
                transform.rotation = Quaternion.Euler(0, 0, Mathf.MoveTowards(currentAngle, stopAngleOpen, spinSpeed * Time.deltaTime));
                /*rigidBody.constraints = RigidbodyConstraints2D.None;
                rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
                rigidBody.AddTorque(spinSpeed * Time.fixedDeltaTime, ForceMode2D.Force);*/
            }
            else
            {
                //rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        else
        {
            if (currentAngle > stopAngleClose + 1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, Mathf.MoveTowards(currentAngle, stopAngleClose, spinSpeed * Time.deltaTime));
                /*rigidBody.constraints = RigidbodyConstraints2D.None;
                rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
                rigidBody.AddTorque(-spinSpeed * Time.fixedDeltaTime, ForceMode2D.Force);*/
            }
            else
            {
                //rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
    
}
