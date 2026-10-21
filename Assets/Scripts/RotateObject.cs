using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;

    void Update()
    {
        // Rotate the solar system around its Y-axis continuously
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}