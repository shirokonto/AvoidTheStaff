using System;
using DataStructures.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Character_Namespace.Scripts
{
    public class PlayerControllerObsolet : MonoBehaviour
    {
        //movement
        [Header("References")]
        [SerializeField] private Vector3IntVariable playerIntPosition;
        [SerializeField] private Vector3Variable playerFloatPosition;

        [Header("Movement")]
        [SerializeField] private float speed = 0.01f;
        private Vector2 _inputMovement;
        private Vector3 _storedInputMovement;
        private PlayerInputAction _playerInputAction;
        private InputAction _movement;

        [Header("Rotating")] 
        private Vector2 _inputRotation;
        private Quaternion _storedInputRotation;
        private static Quaternion rotationFuck; 

        private void Awake()
        {
            _playerInputAction = new PlayerInputAction();
            _playerInputAction.Enable();
        
            //walk
            _playerInputAction.Player.Movement.performed += OnMovement;
            _playerInputAction.Player.Movement.started += OnMovement;
            _playerInputAction.Player.Movement.canceled += OnMovement;
            
            //rotate
            _playerInputAction.Player.Rotate.performed += OnRotate;
            _playerInputAction.Player.Rotate.started += OnRotate;
            _playerInputAction.Player.Rotate.canceled += OnRotate;
        }
    
        private void Update()
        {
            UpdatePlayerMovement();
            UpdatePlayerRotation();

            var position = transform.position;
            playerIntPosition.Set(new Vector3Int(Mathf.RoundToInt(position.x), 0,Mathf.RoundToInt(position.y)));
            playerFloatPosition.Set(position);

        }
    
        private void OnMovement(InputAction.CallbackContext context)
        {
            _inputMovement = context.ReadValue<Vector2>();
            _storedInputMovement = new Vector3(_inputMovement.x,  0, _inputMovement.y);
        }

        private void OnRotate(InputAction.CallbackContext context)
        {
            _inputRotation = context.ReadValue<Vector2>();
            Debug.Log("inputrotation: " + _inputRotation);
            _storedInputRotation = new Quaternion(_inputRotation.x, 0f, _inputRotation.y, 1);
            Debug.Log("_storedInputRotation: " + _storedInputRotation);
        }

        private void OnEnable()
        {
            _movement = _playerInputAction.Player.Movement;
            _movement.Enable();
        }
    
        private void OnDisable()
        {
            _movement.Disable();
        }

        private void UpdatePlayerMovement()
        {
            Vector3 movement = _storedInputMovement * speed * Time.deltaTime;
            Vector3 playerPosition = transform.position;
            playerPosition += movement;
            transform.position = playerPosition;
        }

        private void UpdatePlayerRotation()
        {
            //Vector3 relativePosition = _storedInputRotation - transform.position;
            //float angle = Vector3.Dot(transform.position, _storedInputRotation);
            //Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            Quaternion.Slerp(transform.rotation, _storedInputRotation, Time.deltaTime);

            //transform.rotation = Quaternion.LookRotation(_storedInputRotation);
            //GetComponent<Transform>().Rotate(Vector3.up * _inputRotation.x * .2f);
            
            
        }
    }
}
