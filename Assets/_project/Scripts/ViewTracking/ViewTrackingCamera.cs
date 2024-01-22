using _project.Scripts.Configs;
using _project.Scripts.Configs.Base;
using UnityEngine;

namespace _project.Scripts.ViewTracking
{
    public class ViewTrackingCamera : MonoBehaviour, IGuidable<ViewTrackingCameraConfig>
    {
        [SerializeField] private Camera _camera;
        
        private ViewTrackingCameraConfig _config;
        private Vector3 _startPosition;
        private Vector3 _endPoint;
        private Vector3 _targetPosition;
        private float _rightLimit;
        private float _leftLimit;
        private ITrackable _trackableItem;

        private void FixedUpdate()
        {
            _endPoint = Vector3.MoveTowards(transform.position, _trackableItem.CurrentPosition, _config.MoveSpeed);
            _targetPosition.x = Mathf.Clamp(_endPoint.x, _leftLimit, _rightLimit);

            if (_endPoint.y > _startPosition.y)
            {
                _targetPosition.y = _endPoint.y;
            }
        
            transform.position = _targetPosition;
        }

        public void Guide(ViewTrackingCameraConfig config)
        {
            _config = config;
        
            _startPosition = transform.position;
            _startPosition.y = _config.YAxisOffset;
            _startPosition.z = _config.ZAxisOffset;
        
            _targetPosition = _startPosition;
        }
    
        public void Set(ITrackable trackableItem, float lefBound, float rightBound)
        {
            var limitOffset = _camera.aspect * _camera.orthographicSize;
            
            _trackableItem = trackableItem;
            _leftLimit = lefBound + limitOffset;
            _rightLimit = rightBound - limitOffset;
        }
    }
}