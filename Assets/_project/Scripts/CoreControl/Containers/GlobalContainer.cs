using System.Collections.Generic;
using _project.Scripts.CoreControl.Handlers.Base;
using IContainer = _project.Scripts.CoreControl.Containers.Base.IContainer;

namespace _project.Scripts.CoreControl.Containers
{
    public class GlobalContainer : IContainer
    {
        private static GlobalContainer _instance;
    
        public List<IHandler> Handlers { get; }

        private GlobalContainer()
        {
            Handlers = new List<IHandler>();
        }

        public static GlobalContainer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GlobalContainer();
            }
        
            return _instance;
        }
    }
}