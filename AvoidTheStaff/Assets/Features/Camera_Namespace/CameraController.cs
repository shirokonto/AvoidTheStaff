using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + ((Quaternion.Slerp(target.rotation, transform.rotation,2))* offset);
        transform.rotation = target.rotation * Quaternion.Euler(20, 0, 0);
    }
}
