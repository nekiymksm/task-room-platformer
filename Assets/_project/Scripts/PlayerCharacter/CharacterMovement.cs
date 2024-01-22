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

        public bool IsGrounded { get; private set; }

        private void FixedUpdate()
        {
            _moveDirection.x = _inputHandler.HorizontalAxis;
            _moveDirection.y = _inputHandler.JumpAxis;

            if (IsGrounded && _rigidbody.velocity.magnitude < _characterConfig.MaxMoveSpeed)
            {
                _rigidbody.AddForce(_moveDirection * _characterConfig.MoveForce, ForceMode.Impulse);
            }

            if (IsGrounded && _moveDirection.y > 0)
            {
                _rigidbody.AddForce(Vector3.up * _characterConfig.JumpForce, ForceMode.Impulse);
            }
            
            transform.rotation = _rigidbody.velocity.magnitude < 0
                ? Quaternion.Euler(Vector3.zero)
                : Quaternion.Euler(0, _inputHandler.HorizontalAxis * -90, 0);
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
    }
}