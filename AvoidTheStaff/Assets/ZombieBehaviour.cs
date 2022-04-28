using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
        public float attackSpeed = 4;
        public float attackDistance;
        [SerializeField] private Transform playerTransform;
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
            UpdateRotation();
        }

        private void UpdateMovement()
        {
            Vector3 direction = playerTransform.position - transform.position;

            direction = direction.normalized;

            Vector3 velocity = direction * attackSpeed;
            _animator.SetFloat(MoveSpeed, attackSpeed);

            _controller.Move(velocity * Time.deltaTime);
        }

        private void UpdateRotation()
        {
            
        }
}
