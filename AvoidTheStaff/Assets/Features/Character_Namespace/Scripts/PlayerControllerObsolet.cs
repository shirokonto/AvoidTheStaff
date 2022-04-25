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

        [Header("Balancing")]
        [SerializeField] private float speed = 0.01f;
        [SerializeField] private float movementSmoothingSpeed = 1f;
    
        private Vector3 _smoothInputMovement;
        private Vector2 _inputMovement;
        private Vector3 _storedInputMovement;
        private PlayerInputAction _playerInputAction;
        private InputAction _movement;

        private void Awake()
        {
            _playerInputAction = new PlayerInputAction();
            _playerInputAction.Enable();
        
            //walk
            _playerInputAction.Player.Movement.performed += OnMovement;
            _playerInputAction.Player.Movement.started += OnMovement;
            _playerInputAction.Player.Movement.canceled += OnMovement;
        }
    
        private void Update()
        {
            CalculateMovementInputSmoothing();
            UpdatePlayerMovement();

            var position = transform.position;
            playerIntPosition.Set(new Vector3Int(Mathf.RoundToInt(position.x), 0,Mathf.RoundToInt(position.y)));
            playerFloatPosition.Set(position);
        }
    
        private void OnMovement(InputAction.CallbackContext context)
        {
            _inputMovement = context.ReadValue<Vector2>();
            _storedInputMovement = new Vector3(_inputMovement.x,  0, _inputMovement.y);
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
        private void CalculateMovementInputSmoothing()
        {
            _smoothInputMovement = Vector3.Lerp(_smoothInputMovement, _storedInputMovement, Time.deltaTime * movementSmoothingSpeed);
        }
    
        private void UpdatePlayerMovement()
        {
            Vector3 movement = _smoothInputMovement * speed * Time.deltaTime;
            Vector3 playerPosition = transform.position;
            playerPosition += movement;
            transform.position = playerPosition;
        }
    }
}
