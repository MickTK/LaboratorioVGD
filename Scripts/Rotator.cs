using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 500f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }
}
