using _project.Scripts.Configs;
using _project.Scripts.Configs.Base;
using _project.Scripts.CoreControl;
using _project.Scripts.CoreControl.Base;
using _project.Scripts.Features.Location.Base;
using _project.Scripts.Features.Player;
using _project.Scripts.Features.Scenes.Base;
using _project.Scripts.Features.ViewTracking.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _project.Scripts.Features.Location
{
    public class LocationLoadHandler : IHandler
    {
        private GlobalContainer _globalContainer;
        private ConfigsCollection _configsCollection;
        private LocationView _currentLocationView;
        private SceneType _lastSceneType;
        private bool _isFirstLoad;

        public void Init(HandlersContainer handlersContainer)
        {
            _globalContainer = GlobalContainer.Instance;
            _configsCollection = handlersContainer.ConfigsCollection;
            _lastSceneType = SceneType.Init;
            _isFirstLoad = true;
        }

        public void Run()
        {
        }

        public void Load(SceneType sceneType)
        {
            var exitPoint = _isFirstLoad ? Vector3.zero : _currentLocationView.ExitBound.transform.position;
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)sceneType));

            _currentLocationView = _configsCollection.GetConfig<LocationConfig>().GetLocation(sceneType);
            _currentLocationView.Set(exitPoint);
            _currentLocationView.ExitBound.CharacterExit += OnLocationExit;

            if (_isFirstLoad)
            {
                OnFirstLoad();
                _isFirstLoad = false;
            }
            else
            {
                SceneManager.UnloadSceneAsync((int)_lastSceneType);
            }
        
            if (_globalContainer.TryGetHandler(out PlayerCharacterInstanceHandler characterHandler))
            {
                TrySetCamera(characterHandler.GetInstance());
            }
        
            _lastSceneType = sceneType;
        }
    
        private void OnFirstLoad()
        {
            if (_globalContainer.TryGetHandler(out PlayerCharacterInstanceHandler characterHandler))
            {
                var character = characterHandler.GetInstance();
                character.transform.position = _currentLocationView.CharacterLoadPointTransform.position;

                TrySetCamera(character);
            }
        }
    
        private void TrySetCamera(ITrackable character)
        {
            if (_globalContainer.TryGetHandler(out ViewTrackingCameraInstanceHandler cameraHandler))
            {
                cameraHandler.GetInstance().Set(character, 
                    _currentLocationView.EnterBound.transform.position.x, 
                    _currentLocationView.ExitBound.transform.position.x);
            }
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