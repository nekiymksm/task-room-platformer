using _project.Scripts.Configs;
using _project.Scripts.Configs.Base;
using _project.Scripts.CoreControl;
using _project.Scripts.CoreControl.Base;
using _project.Scripts.Features.Location.Base;
using _project.Scripts.Features.Player;
using _project.Scripts.Features.Scenes.Base;
using _project.Scripts.Features.ViewTracking.Base;
using _project.Scripts.Ui.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _project.Scripts.Features.Location
{
    public class LocationLoadHandler : IHandler
    {
        private GlobalContainer _globalContainer;
        private PlayerCharacterInstanceHandler _playerCharacterInstanceHandler;
        private ConfigsCollection _configsCollection;
        private LocationView _currentLocationView;
        private SceneType _lastSceneType;

        public bool IsFirstLoad { private get; set; }

        public void Init(HandlersContainer handlersContainer)
        {
            _globalContainer = GlobalContainer.Instance;
            _playerCharacterInstanceHandler = _globalContainer.GetHandler<PlayerCharacterInstanceHandler>();
            _configsCollection = handlersContainer.ConfigsCollection;
            _lastSceneType = SceneType.Init;
            IsFirstLoad = true;
        }

        public void Run()
        {
        }

        public void Load(SceneType sceneType)
        {
            var exitPoint = IsFirstLoad ? Vector3.zero : _currentLocationView.ExitBound.transform.position;
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)sceneType));

            _currentLocationView = _configsCollection.GetConfig<LocationConfig>().GetLocation(sceneType);
            _currentLocationView.Set(exitPoint);
            _currentLocationView.ExitBound.CharacterExit += OnLocationExit;

            if (IsFirstLoad)
            {
                OnFirstLoad();
                IsFirstLoad = false;
            }
            else
            {
                SceneManager.UnloadSceneAsync((int)_lastSceneType);
            }
            
            TrySetCamera(_playerCharacterInstanceHandler.GetInstance());

            _lastSceneType = sceneType;
        }
    
        private void OnFirstLoad()
        {
            var character = _playerCharacterInstanceHandler.GetInstance();
            character.transform.position = _currentLocationView.CharacterLoadPointTransform.position;

            TrySetCamera(character);

            var sessionUiHandler = _globalContainer.GetHandler<SessionUiInstanceHandler>().GetInstance();
            sessionUiHandler.Init(_globalContainer);
            sessionUiHandler.Run();
        }
    
        private void TrySetCamera(ITrackable character)
        {
            _globalContainer.GetHandler<ViewTrackingCameraInstanceHandler>().GetInstance()
                .Set(character, 
                    _currentLocationView.EnterBound.transform.position.x, 
                    _currentLocationView.ExitBound.transform.position.x);
        }
    
        private void OnLocationExit()
        {
            _currentLocationView.ExitBound.CharacterExit -= OnLocationExit;
            SceneManager.LoadScene((int) GetNextLocationType(), LoadSceneMode.Additive);
        }

        private SceneType GetNextLocationType()
        {
            switch (_lastSceneType)
            {
                case SceneType.Init:
                case SceneType.Level:
                    return SceneType.Pass;
            
                case SceneType.Pass:
                    return SceneType.Level;
            }
        
            return SceneType.Pass;
        }
    }
}