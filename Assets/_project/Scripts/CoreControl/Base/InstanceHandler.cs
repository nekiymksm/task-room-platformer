using _project.Scripts.Configs.Base;
using UnityEngine;

namespace _project.Scripts.CoreControl.Base
{
    public abstract class InstanceHandler<T> : IHandler where T : Object
    {
        private T _instance;
        protected ConfigsCollection ConfigsCollection;

        public void Init(HandlersContainer handlersContainer)
        {
            ConfigsCollection = handlersContainer.ConfigsCollection;
        }

        public void Run()
        {
        }
        
        protected abstract T Create();
        
        public T GetInstance()
        {
            if (_instance == null)
            {
                _instance = Create();
                Object.DontDestroyOnLoad(_instance);
            }
        
            return _instance;
        }

        public void Destroy()
        {
            Object.Destroy(_instance);
            _instance = null;
        }
    }
}