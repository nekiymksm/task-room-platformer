using _project.Scripts.ViewTracking;
using UnityEngine;

public class CharacterTracker : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector3 _startPosition;
    private Vector3 _endPoint;
    private Vector3 _targetPosition;

    public ITrackable TrackingItem { private get; set; }

    private void Start()
    {
        _startPosition = transform.position;
        _targetPosition = _startPosition;
    }

    private void FixedUpdate()
    {
        _endPoint = Vector3.MoveTowards(transform.position, TrackingItem.CurrentPosition, _moveSpeed);
        _targetPosition.x = _endPoint.x;

        if (_endPoint.y > _startPosition.y)
        {
            _targetPosition.y = _endPoint.y;
        }
        
        transform.position = _targetPosition;
    }
}