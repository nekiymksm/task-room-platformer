using System.Collections.Generic;
using _project.Scripts.CoreControl.Handlers.Base;

namespace _project.Scripts.CoreControl.Containers.Base
{
    public interface IContainer
    {
        public List<IHandler> Handlers { get; }

        public bool TryGetHandler<T>(out T handler) where T : class, IHandler
        {
            foreach (var item in Handlers)
            {
                if (item.GetType() == typeof(T))
                {
                    handler = item as T;
                    return true;
                }
            }

            handler = null;
            return false;
        }
    }
}