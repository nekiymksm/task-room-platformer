using _project.Scripts.CoreControl.Base;
using _project.Scripts.Features.Input;
using _project.Scripts.Features.Location;
using _project.Scripts.Features.Player;
using _project.Scripts.Features.Scenes.Base;
using _project.Scripts.Features.ViewTracking.Base;
using _project.Scripts.Ui.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _project.Scripts.CoreControl
{
    public class GlobalContainer : HandlersContainer
    {
        public static GlobalContainer Instance;

        [SerializeField] private InputHandler _inputHandler;

        private LocationLoadHandler _locationLoadHandler;
        private PlayerCharacterInstanceHandler _playerCharacterInstanceHandler;
        private ViewTrackingCameraInstanceHandler _viewTrackingCameraInstanceHandler;
        private SessionUiInstanceHandler _sessionUiInstanceHandler;
        
        protected override void OnInit()
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;

            _locationLoadHandler = new LocationLoadHandler();
            _playerCharacterInstanceHandler = new PlayerCharacterInstanceHandler();
            _viewTrackingCameraInstanceHandler = new ViewTrackingCameraInstanceHandler();
            _sessionUiInstanceHandler = new SessionUiInstanceHandler();
            
            AddHandler(_locationLoadHandler);
            AddHandler(_playerCharacterInstanceHandler);
            AddHandler(_viewTrackingCameraInstanceHandler);
            AddHandler(_inputHandler);
            AddHandler(_sessionUiInstanceHandler);
        }

        protected override void OnRun()
        {
            SceneManager.LoadScene((int)SceneType.Menu);
        }

        public void ResetInstances()
        {
            _locationLoadHandler.IsFirstLoad = true;
            _playerCharacterInstanceHandler.CollapseInstance();
            _viewTrackingCameraInstanceHandler.CollapseInstance();
            _sessionUiInstanceHandler.CollapseInstance();
        }
    }
}