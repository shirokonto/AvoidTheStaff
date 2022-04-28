using DataStructures.Variables;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    private float _angle;
    private Animator _animator;
    private static readonly int Move = Animator.StringToHash("Move");

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }

    private void UpdateMovement()
    {
        float moveVertical = Input.GetAxis("Vertical");
        transform.position += moveVertical * speed * transform.forward;
        _animator.SetFloat(Move, moveVertical);
    }

    private void UpdateRotation()
    {
        float rotate = Input.GetAxis("Horizontal");
        _angle += rotate * 0.025f;
        Vector3 targetDirection = new Vector3(Mathf.Sin(_angle), 0f, Mathf.Cos(_angle));
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }
}
