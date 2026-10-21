using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform center;
    public float orbitSpeed = 20f;
    public float spinSpeed = 50f;

    void Update()
    {
        if (center != null) {
            transform.RotateAround(center.position, center.up, orbitSpeed * Time.deltaTime);
        }
        transform.Rotate(0f,spinSpeed*Time.deltaTime,0f,Space.Self);
    }
}
