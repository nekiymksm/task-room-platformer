using System.Collections.Generic;
using _project.Scripts.Configs;
using _project.Scripts.Utils;
using UnityEngine;

namespace _project.Scripts.CoreControl.Base
{
    public abstract class HandlersContainer : MonoBehaviour
    {
        [field: SerializeField] public ConfigsCollection ConfigsCollection { get; private set; }

        private List<IHandler> _handlers;

        private void Awake()
        {
            _handlers = new List<IHandler>();

            OnInit();
            
            foreach (var handler in _handlers)
            {
                handler.Init(this);
            }
        }

        private void Start()
        {
            OnRun();
        
            foreach (var handler in _handlers)
            {
                handler.Run();
            }
        }

        protected void AddHandler(IHandler handler)
        {
            _handlers.Add(handler);
        }
        
        protected virtual void OnInit()
        {
        }
    
        protected virtual void OnRun()
        {
        }
        
        public bool TryGetHandler<T>(out T handler) where T : class, IHandler
        {
            return CollectionItemSearcher.TryGetItem(_handlers, out handler);
        }
    }
}