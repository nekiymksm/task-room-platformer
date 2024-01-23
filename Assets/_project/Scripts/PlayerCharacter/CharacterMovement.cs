using _project.Scripts.Configs;
using _project.Scripts.CoreControl.Handlers;
using UnityEngine;

namespace _project.Scripts.PlayerCharacter
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _contactPointTransform;

        private CharacterConfig _characterConfig;
        private InputHandler _inputHandler;
        private Vector3 _moveDirection;
        private Vector3 _moveRotation;

        public bool IsGrounded { get; private set; }

        private void FixedUpdate()
        {
            _moveDirection.x = _inputHandler.HorizontalAxis;
            _moveDirection.y = _inputHandler.JumpAxis;

            if (IsGrounded && Mathf.Abs(_rigidbody.velocity.x) < _characterConfig.MaxMoveSpeed)
            {
                _rigidbody.AddForce(_moveDirection * _characterConfig.MoveForce, ForceMode.Impulse);
            }

            if (IsGrounded && _moveDirection.y > 0)
            {
                _rigidbody.AddForce(Vector3.up * _characterConfig.JumpForce, ForceMode.Impulse);
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

        public void Init(CharacterConfig characterConfig, InputHandler inputHandler)
        {
            _characterConfig = characterConfig;
            _inputHandler = inputHandler;
        }

        private void SetRotation()
        {
            if (_moveDirection.x == 0 && Mathf.Abs(_rigidbody.velocity.x) < 0.5f)
            {
                _moveRotation.y = Mathf.Lerp(_moveRotation.y, 0, _characterConfig.RotationSpeed);
            }
            else
            {
                switch (_moveDirection.x)
                {
                    case > 0:
                        _moveRotation.y = Mathf.Lerp(_moveRotation.y, -90, _characterConfig.RotationSpeed);
                        break;
                
                    case < 0:
                        _moveRotation.y = Mathf.Lerp(_moveRotation.y, 90, _characterConfig.RotationSpeed);
                        break;
                }
            }
            
            _rigidbody.MoveRotation(Quaternion.Euler(_moveRotation));
        }
    }
}