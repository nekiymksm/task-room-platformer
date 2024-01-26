using _project.Scripts.Configs;
using _project.Scripts.Features.Input;
using _project.Scripts.Features.Location.Items;
using UnityEngine;

namespace _project.Scripts.Features.Player
{
    public class PlayerCharacterMovement : MonoBehaviour
    {
        [SerializeField] private Collider _mainCollider;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _contactPointTransform;

        private PlayerCharacterConfig _playerCharacterConfig;
        private InputHandler _inputHandler;
        private PlayerCharacterAnimationsControl _animationsControl;
        private Vector3 _moveDirection;
        private Vector3 _moveRotation;
        private bool _isGrounded;
        private bool _canMove;
        
        private void Start()
        {
            _inputHandler.JumpButtonDown += OnJump;
        }

        private void FixedUpdate()
        {
            if (_canMove == false)
            {
                return;
            }
            
            _moveDirection.x = _inputHandler.HorizontalAxisValue;

            if (_isGrounded)
            {
                if (Mathf.Abs(_rigidbody.velocity.x) < _playerCharacterConfig.MaxMoveSpeed)
                {
                    _rigidbody.AddForce(_moveDirection * _playerCharacterConfig.MoveForce, ForceMode.Impulse);
                }
                
                _animationsControl.PlayRun(Mathf.Abs(_moveDirection.x) > 0);
            }

            SetRotation();
        }

        private void OnDestroy()
        {
            _inputHandler.JumpButtonDown -= OnJump;
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Platform platform))
            {
                foreach (var contact in collision.contacts)
                {
                    if (contact.point.y <= _contactPointTransform.position.y)
                    {
                        _isGrounded = true;
                    }
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Platform platform))
            {
                _isGrounded = false;
            }
        }

        public void Init(PlayerCharacterConfig playerCharacterConfig, InputHandler inputHandler, 
            PlayerCharacterAnimationsControl animationsControl)
        {
            _playerCharacterConfig = playerCharacterConfig;
            _inputHandler = inputHandler;
            _animationsControl = animationsControl;
        }

        public void SetBlocking(bool isBlock)
        {
            _canMove = !isBlock;
            _rigidbody.detectCollisions = !isBlock;
            _rigidbody.isKinematic = isBlock;
            _mainCollider.enabled = !isBlock;
            enabled = !isBlock;
        }

        private void SetRotation()
        {
            switch (_moveDirection.x)
            {
                case > 0:
                {
                    _moveRotation.y = Mathf.Lerp(_moveRotation.y, -90, _playerCharacterConfig.RotationSpeed);
                }
                    break;

                case < 0:
                {
                    _moveRotation.y = Mathf.Lerp(_moveRotation.y, 90, _playerCharacterConfig.RotationSpeed); 
                }
                    break;

                case 0:
                {
                    if (_isGrounded && Mathf.Abs(_rigidbody.velocity.x) < 0.5f)
                    {
                        _moveRotation.y = Mathf.Lerp(_moveRotation.y, 0, _playerCharacterConfig.RotationSpeed);
                    } 
                }
                    break;
            }

            _rigidbody.MoveRotation(Quaternion.Euler(_moveRotation));
        }

        private void OnJump()
        {
            if (_canMove == false)
            {
                return;
            }
            
            if (_isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _playerCharacterConfig.JumpForce, ForceMode.Impulse);
                _animationsControl.PlayJump();
            }
        }
    }
}