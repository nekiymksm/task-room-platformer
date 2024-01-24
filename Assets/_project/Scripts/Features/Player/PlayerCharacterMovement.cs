using _project.Scripts.Configs;
using _project.Scripts.Features.Input;
using _project.Scripts.Features.Input.Base;
using _project.Scripts.Features.Location.Items;
using UnityEngine;

namespace _project.Scripts.Features.Player
{
    public class PlayerCharacterMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _contactPointTransform;

        private PlayerCharacterConfig _playerCharacterConfig;
        private InputHandler _inputHandler;
        private Vector3 _moveDirection;
        private Vector3 _moveRotation;

        public bool IsGrounded { get; private set; }

        private void FixedUpdate()
        {
            _moveDirection.x = _inputHandler.GetAxisValue(AxisKind.Horizontal);
            _moveDirection.y = _inputHandler.GetAxisValue(AxisKind.Jump, true);

            if (IsGrounded && Mathf.Abs(_rigidbody.velocity.x) < _playerCharacterConfig.MaxMoveSpeed)
            {
                _rigidbody.AddForce(_moveDirection * _playerCharacterConfig.MoveForce, ForceMode.Impulse);
            }

            if (IsGrounded && _moveDirection.y > 0)
            {
                _rigidbody.AddForce(Vector3.up * _playerCharacterConfig.JumpForce, ForceMode.Impulse);
            }
            
            SetRotation();
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Platform platform))
            {
                foreach (var contact in collision.contacts)
                {
                    if (contact.point.y <= _contactPointTransform.position.y)
                    {
                        IsGrounded = true;
                    }
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Platform platform))
            {
                IsGrounded = false;
            }
        }

        public void Init(PlayerCharacterConfig playerCharacterConfig, InputHandler inputHandler)
        {
            _playerCharacterConfig = playerCharacterConfig;
            _inputHandler = inputHandler;
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
                    if (IsGrounded && Mathf.Abs(_rigidbody.velocity.x) < 0.5f)
                    {
                        _moveRotation.y = Mathf.Lerp(_moveRotation.y, 0, _playerCharacterConfig.RotationSpeed);
                    } 
                }
                    break;
            }

            _rigidbody.MoveRotation(Quaternion.Euler(_moveRotation));
        }
    }
}