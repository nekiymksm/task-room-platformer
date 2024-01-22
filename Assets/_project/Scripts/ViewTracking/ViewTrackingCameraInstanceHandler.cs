using _project.Scripts.Configs;
using _project.Scripts.CoreControl.Handlers.Base;
using UnityEngine;

namespace _project.Scripts.ViewTracking
{
    public class ViewTrackingCameraInstanceHandler : IHandler
    {
        private ConfigsCollection _configsCollection;
        private ViewTrackingCamera _trackingCameraInstance;

        public void Init(HandlersContainer handlersContainer)
        {
            _configsCollection = handlersContainer.ConfigsCollection;
        }

        public void Run()
        {
        }

        public ViewTrackingCamera GetTrackingCamera()
        {
            if (_trackingCameraInstance == null)
            {
                _trackingCameraInstance = _configsCollection.GetConfig<ViewTrackingCameraConfig>().Create();
                Object.DontDestroyOnLoad(_trackingCameraInstance.gameObject);
            }
            
            return _trackingCameraInstance;
        }
    }
}