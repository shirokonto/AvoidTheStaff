using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector3 rotationAngle;
    [SerializeField] private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
    }
}
