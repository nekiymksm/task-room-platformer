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
        private SceneType _lastSceneType;

        public LocationView CurrentLocationView { get; private set; }
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
            var exitPoint = IsFirstLoad ? Vector3.zero : CurrentLocationView.ExitBound.transform.position;
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)sceneType));

            CurrentLocationView = _configsCollection.GetConfig<LocationConfig>().GetLocation(sceneType);
            CurrentLocationView.Set(exitPoint);
            CurrentLocationView.ExitBound.CharacterExit += OnLocationExit;

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
            character.transform.position = CurrentLocationView.CharacterLoadPointTransform.position;

            TrySetCamera(character);

            var sessionUiHandler = _globalContainer.GetHandler<SessionUiInstanceHandler>().GetInstance();
            sessionUiHandler.Init(_globalContainer);
            sessionUiHandler.Run();
        }
    
        private void TrySetCamera(ITrackable character)
        {
            _globalContainer.GetHandler<ViewTrackingCameraInstanceHandler>().GetInstance()
                .Set(character, 
                    CurrentLocationView.EnterBound.transform.position.x, 
                    CurrentLocationView.ExitBound.transform.position.x);
        }
    
        private void OnLocationExit()
        {
            CurrentLocationView.ExitBound.CharacterExit -= OnLocationExit;
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