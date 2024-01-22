using _project.Scripts.Configs;
using _project.Scripts.CoreControl.Containers;
using _project.Scripts.CoreControl.Handlers.Base;
using _project.Scripts.Location.Base;
using _project.Scripts.PlayerCharacter;
using _project.Scripts.ViewTracking;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHandler : IHandler
{
    private GlobalContainer _globalContainer;
    private ConfigsCollection _configsCollection;
    private LoadableLocation _currentLocation;
    private LocationType _lastLocationType;
    private bool _isFirstLoad;

    public void Init(HandlersContainer handlersContainer)
    {
        _globalContainer = GlobalContainer.Instance;
        _configsCollection = handlersContainer.ConfigsCollection;
        _lastLocationType = LocationType.Init;
        _isFirstLoad = true;
    }

    public void Run()
    {
    }

    public void Load(LocationType locationType)
    {
        var exitPoint = _isFirstLoad ? Vector3.zero : _currentLocation.ExitBound.transform.position;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)locationType));

        _currentLocation = _configsCollection.GetConfig<LocationConfig>().GetLocation(locationType);
        _currentLocation.Set(exitPoint);
        _currentLocation.ExitBound.CharacterExit += OnLocationExit;

        if (_isFirstLoad)
        {
            OnFirstLoad();
            _isFirstLoad = false;
        }
        else
        {
            SceneManager.UnloadSceneAsync((int)_lastLocationType);
        }
        
        if (_globalContainer.TryGetHandler(out CharacterInstanceHandler characterHandler))
        {
            TrySetCamera(characterHandler.GetCharacter());
        }
        
        _lastLocationType = locationType;
    }
    
    private void OnFirstLoad()
    {
        if (_globalContainer.TryGetHandler(out CharacterInstanceHandler characterHandler))
        {
            var character = characterHandler.GetCharacter();
            character.transform.position = _currentLocation.CharacterLoadPointTransform.position;

            TrySetCamera(character);
        }
    }
    
    private void TrySetCamera(ITrackable character)
    {
        if (_globalContainer.TryGetHandler(out ViewTrackingCameraInstanceHandler cameraHandler))
        {
            cameraHandler.GetTrackingCamera().Set(character, 
                _currentLocation.EnterBound.transform.position.x, 
                _currentLocation.ExitBound.transform.position.x);
        }
    }
    
    private void OnLocationExit()
    {
        _currentLocation.ExitBound.CharacterExit -= OnLocationExit;
        SceneManager.LoadScene((int) GetNextLocationType(), LoadSceneMode.Additive);
    }

    private LocationType GetNextLocationType()
    {
        switch (_lastLocationType)
        {
            case LocationType.Init:
            case LocationType.Level:
                return LocationType.Pass;
            
            case LocationType.Pass:
                return LocationType.Level;
        }
        
        return LocationType.Pass;
    }
}