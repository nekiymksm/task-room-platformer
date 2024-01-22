using _project.Scripts.Configs;
using _project.Scripts.CoreControl.Handlers.Base;
using UnityEngine;

namespace _project.Scripts.PlayerCharacter
{
    public class CharacterInstanceHandler : IHandler
    {
        private ConfigsCollection _configsCollection;
        private Character _characterInstance;

        public void Init(HandlersContainer handlersContainer)
        {
            _configsCollection = handlersContainer.ConfigsCollection;
        }

        public void Run()
        {
        }

        public Character GetCharacter()
        {
            if (_characterInstance == null)
            {
                _characterInstance = _configsCollection.GetConfig<CharacterConfig>().Create();
                Object.DontDestroyOnLoad(_characterInstance.gameObject);
            }
        
            return _characterInstance;
        }
    }
}