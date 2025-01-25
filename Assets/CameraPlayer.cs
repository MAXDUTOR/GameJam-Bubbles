using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform target; 
    public float smoothing = 5f;
    public Vector3 offset = new Vector3(0f, 0f, -5f);

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset; 
            targetPosition.y = transform.position.y; 
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
