using _project.Scripts.Configs;
using _project.Scripts.CoreControl.Base;
using UnityEngine;

namespace _project.Scripts.Features.Player
{
    public class PlayerCharacterInstanceHandler : IHandler
    {
        private ConfigsCollection _configsCollection;
        private PlayerCharacterInstance _playerCharacterInstance;

        public void Init(HandlersContainer handlersContainer)
        {
            _configsCollection = handlersContainer.ConfigsCollection;
        }

        public void Run()
        {
        }

        public PlayerCharacterInstance GetCharacter()
        {
            if (_playerCharacterInstance == null)
            {
                _playerCharacterInstance = _configsCollection.GetConfig<PlayerCharacterConfig>().Create();
                Object.DontDestroyOnLoad(_playerCharacterInstance.gameObject);
            }
        
            return _playerCharacterInstance;
        }
    }
}