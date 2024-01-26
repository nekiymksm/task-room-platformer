using _project.Scripts.Configs.Base;
using UnityEngine;

namespace _project.Scripts.CoreControl.Base
{
    public abstract class InstanceHandler<T> : IHandler where T : MonoBehaviour
    {
        private T _instance;
        protected ConfigsCollection ConfigsCollection;

        public void Init(HandlersContainer handlersContainer)
        {
            ConfigsCollection = handlersContainer.ConfigsCollection;
        }

        public void Run()
        {
            OnRun();
        }
        
        public T GetInstance()
        {
            if (_instance == null)
            {
                _instance = Create();
                Object.DontDestroyOnLoad(_instance.gameObject);
            }
        
            return _instance;
        }

        public void CollapseInstance()
        {
            Object.Destroy(_instance.gameObject);
            _instance = null;
        }
        
        protected abstract T Create();

        protected virtual void OnRun()
        {
        }
    }
}