using UnityEngine;

namespace Features.Camera_Namespace
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float interpolationRatio;
        [SerializeField] private float rotationX;
    
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //Delayed panning of camera using Slerp
            transform.position = target.position + ((Quaternion.Slerp(target.rotation, transform.rotation,interpolationRatio))* offset);
            //rotation around x axis
            transform.rotation = target.rotation * Quaternion.Euler(rotationX, 0, 0);
        }
    }
}
