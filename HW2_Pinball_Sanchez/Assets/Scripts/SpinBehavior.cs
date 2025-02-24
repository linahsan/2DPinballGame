using UnityEngine;

public class SpinBehavior : MonoBehaviour
{
    [SerializeField] float spinSpeed = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        
    }
}
