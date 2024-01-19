using _project.Scripts.ViewTracking;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour, ITrackable
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _contactPointTransform;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _jumpForce;

    private Vector3 _moveDirection;
    private bool _isGrounded;

    public Vector3 CurrentPosition { get; private set; }

    private void Start()
    {
        if (Camera.main.TryGetComponent(out CharacterTracker tracker))
        {
            tracker.TrackingItem = this;
        }
    }

    private void FixedUpdate()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        _moveDirection.y = Input.GetAxis("Jump");
        
        if (_isGrounded && _rigidbody.velocity.magnitude < _maxMoveSpeed)
        {
            _rigidbody.AddForce(_moveDirection * _moveSpeed, ForceMode.Impulse);
        }
        
        if (_isGrounded && _moveDirection.y > 0)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        CurrentPosition = transform.position;
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
}