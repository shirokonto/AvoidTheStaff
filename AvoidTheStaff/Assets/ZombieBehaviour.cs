using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed;
        private CharacterController _controller;
        private Animator _animator;
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _controller = GetComponent<CharacterController>();
        }
    
        // Update is called once per frame
        void Update()
        {
            UpdateMovement();
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            Vector3 direction = playerTransform.position - transform.position;
            direction = direction.normalized;

            Vector3 velocity = direction * speed;
            _animator.SetFloat(MoveSpeed, speed);

            _controller.Move(velocity * Time.deltaTime);
        }
}
